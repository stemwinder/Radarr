﻿using System.Collections.Generic;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.Messaging.Events;

namespace NzbDrone.Core.Download.Pending
{
    public interface IPendingReleaseRepository : IBasicRepository<PendingRelease>
    {
        void DeleteBySeriesId(int seriesId);
        List<PendingRelease> AllBySeriesId(int seriesId);
        void DeleteByMovieId(int movieId);
        List<PendingRelease> AllByMovieId(int movieId);
    }

    public class PendingReleaseRepository : BasicRepository<PendingRelease>, IPendingReleaseRepository
    {
        public PendingReleaseRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }

        public void DeleteBySeriesId(int seriesId)
        {
            Delete(r => r.SeriesId == seriesId);
        }

        public List<PendingRelease> AllBySeriesId(int seriesId)
        {
            return Query.Where(p => p.SeriesId == seriesId);
        }

        public void DeleteByMovieId(int movieId)
        {
            Delete(r => r.MovieId == movieId);
        }

        public List<PendingRelease> AllByMovieId(int movieId)
        {
            return Query.Where(p => p.MovieId == movieId);
        }
    }
}