//using CarRentalGraphQL.Models;
//using HotChocolate.Execution;
//using HotChocolate.Subscriptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExampleGraphQL.DataAccess
//{
//    public class Subscription
//    {
//        [SubscribeAndResolve]
//        public async ValueTask<ISourceStream<Post>>
//            OnPostCreate([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellation)
//        {
//            return await
//                eventReceiver.SubscribeAsync
//        }
//    }
//}
