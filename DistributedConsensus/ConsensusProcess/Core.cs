using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


namespace WebOfTrustConsensus
{
    /// <summary>
    /// Mockup of Forms Checkbox, allows for testing
    /// </summary>
    public class DataQueue
    {
        public bool IsProcessing { get; set; }
    }

    public partial class ConsensusCore  
    {

        DataQueue dataQueue1 = new DataQueue();
        DataQueue dataQueue2 = new DataQueue();
        DataQueue dataQueue3 = new DataQueue();
        DataQueue dataQueue4 = new DataQueue();

        // Create a Timer object that sends out transaction summary every N seconds
        static Timer ProposalTimer = null;

        // Broadcasts values to an ActionBlock<int> object that is associated
        // with each check box.
        BroadcastBlock<int> broadcaster = new BroadcastBlock<int>(null);

        public ConsensusCore()
        {
            // todo: add logic to allow for 
            ProposalTimer = new Timer(ProposalTimerCallback, null, 0, 2000);

            // Create an ActionBlock<DataQueue> object that toggles the state
            // of DataQueue objects.
            // Specifying the current synchronization context enables the 
            // action to run on the user-interface thread.
            var toggleQueueState = new ActionBlock<DataQueue>(monitor =>
            {
                monitor.IsProcessing = !monitor.IsProcessing;
            },
            new ExecutionDataflowBlockOptions
            {
                TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
            });

            // Create a ConcurrentExclusiveSchedulerPair object.
            // Readers will run on the concurrent part of the scheduler pair.
            // The writer will run on the exclusive part of the scheduler pair.
            var taskSchedulerPair = new ConcurrentExclusiveSchedulerPair();

            // Create an ActionBlock<int> object for each reader DataQueue object.
            // Each ActionBlock<int> object represents an action that can read 
            // from a resource in parallel to other readers.
            // Specifying the concurrent part of the scheduler pair enables the 
            // reader to run in parallel to other actions that are managed by 
            // that scheduler.
            var verifyDataSignature =
               from queue in new DataQueue[] { dataQueue1, dataQueue2, dataQueue3, dataQueue4 }
               select new ActionBlock<int>(milliseconds =>
               {
                   // Toggle the check box to the checked state.
                   toggleQueueState.Post(queue);

                   // Perform the cryptographic verification of the payload
                   Thread.Sleep(milliseconds);

                   // Toggle the check box to the unchecked state.
                   toggleQueueState.Post(queue);
               },
               new ExecutionDataflowBlockOptions
               {
                   TaskScheduler = taskSchedulerPair.ConcurrentScheduler
               });

            // Create an ActionBlock<int> object for the writer DataQueue object.
            // This ActionBlock<int> object represents an action that writes to 
            // a resource, but cannot run in parallel to readers.
            // Specifying the exclusive part of the scheduler pair enables the 
            // writer to run in exclusively with respect to other actions that are 
            // managed by the scheduler pair.
            var writerAction = new ActionBlock<int>(milliseconds =>
            {
                // Toggle the check box to the checked state.
                toggleQueueState.Post(dataQueue4);

                // Perform the write action. For demonstration, suspend the current
                // thread to simulate a lengthy write operation.
                Thread.Sleep(milliseconds);

                // Toggle the check box to the unchecked state.
                toggleQueueState.Post(dataQueue4);
            },
            new ExecutionDataflowBlockOptions
            {
                TaskScheduler = taskSchedulerPair.ExclusiveScheduler
            });

            // Link the broadcaster to each reader and writer block.
            // The BroadcastBlock<T> class propagates values that it 
            // receives to all connected targets.
            foreach (var verifyAction in verifyDataSignature)
            {
                broadcaster.LinkTo(verifyAction);
            }
            broadcaster.LinkTo(writerAction);


            //ProposalTimer.Dispose();
        }

        /// <summary>
        /// Converge the timer skew using this interval adjustment
        /// </summary>
        private static void AdjustTimerSyncInterval(int medianOfReplies)
        {
            int interval = 0;
            int period = 0;

            ConsensusCore.ProposalTimer.Change(interval, period);
        }

        // Event handler for the timer.
        private static void ProposalTimerCallback(Object o)
        {
            // Post a value to the broadcaster. The broadcaster
            // sends this message to each target. 
            //broadcaster.Post(1000);

            Console.WriteLine("Promote Proposals to Transactions: {0}", DateTime.Now.ToString("h:mm:ss"));
        }
    }
}