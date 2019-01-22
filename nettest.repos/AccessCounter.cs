using System;
using StackExchange.Redis;

namespace nettest.repos
{
    public class AccessCounter
    {
        public static long UpdateCount()
        {
            using(ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis"))
            {
                var db = redis.GetDatabase();
                return db.HashIncrement("hits", "field");
            }
        }
    }
}
