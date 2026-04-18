using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    public class Twitter
    {
        const int FeedSize = 10;
        private int timestamp = 0;
        private readonly IDictionary<int, LinkedList<Tweet>> _userFeed = new Dictionary<int, LinkedList<Tweet>>();
        private readonly IDictionary<int, HashSet<int>> _followers = new Dictionary<int, HashSet<int>>();
        public Twitter()
        {

        }

        private class Tweet
        {
            public int Id { get; set; }

            public int Ts { get; set; }
        }

        public void PostTweet(int userId, int tweetId)
        {
            AddTweetToFeed(userId, tweetId);
            //if(_followers.TryGetValue(userId, out var follow))
            //{
            //    foreach(var item in follow)
            //    {
            //        AddTweetToFeed(item, tweetId);
            //    }
            //}
        }

        private void AddTweetToFeed(int userId, int tweetId)
        {
            var tweet = new Tweet { Id = tweetId, Ts = timestamp++ };
            if(_userFeed.TryGetValue(userId, out var feed))
            {
                if (feed.Count > FeedSize)
                    feed.RemoveLast();
                feed.AddFirst(tweet);
            }
            else
            {
                var list = new LinkedList<Tweet>();
                list.AddFirst(tweet);
                _userFeed.Add(userId, list);
            }
        }

        public IList<int> GetNewsFeed(int userId)
        {
            var users = new List<int>();
            
            var userFeedOffsets = new Dictionary<int, LinkedListNode<Tweet>>();
            var useUserFeeds = new HashSet<int>();
            var res = new List<int>(FeedSize);
            if (_userFeed.TryGetValue(userId, out LinkedList<Tweet> userfeed))
            {
                users.Add(userId);
                userFeedOffsets.Add(userId, userfeed.First);
            }
            if(_followers.TryGetValue(userId, out var fol))
            {
                foreach(var f in fol)
                {
                    if(_userFeed.TryGetValue(f, out var ffeed))
                    {
                        users.Add(f);
                        userFeedOffsets.Add(f, ffeed.First);
                    }
                    

                }
            }
            

            //LinkedList<int> nextFeedGeter = null;
            while(res.Count != FeedSize)
            {
                var nextTweetId = -1;
                var nextTweetTs = -1;
                var nextTweetUserId = -1;
                LinkedListNode<Tweet> nextFeedGeter = null;
                foreach (var user in users)
                {
                    if(userFeedOffsets.TryGetValue(user, out var currFeed) && currFeed.Value.Ts > nextTweetTs)
                    {
                        nextTweetId = currFeed.Value.Id;
                        nextFeedGeter = currFeed;
                        nextTweetTs = currFeed.Value.Ts;
                        nextTweetUserId = user;
                    }
                }

                if (nextTweetTs == -1)
                    break;

                res.Add(nextTweetId);
                if (nextFeedGeter.Next == null)
                {
                    userFeedOffsets.Remove(nextTweetUserId);
                }
                else
                {
                    userFeedOffsets[nextTweetUserId] = nextFeedGeter.Next;
                }
            }
            return res;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (_followers.TryGetValue(followerId, out var set))
            {
                set.Add(followeeId);
            }
            else
            {
                set = new HashSet<int>();
                set.Add(followeeId);
                _followers.Add(followerId, set);
            }
        }

        public void Unfollow(int followerId, int followeeId)
        {
            if (_followers.TryGetValue(followerId, out var set))
            {
                set.Remove(followeeId);
            }
        }
    }
}
