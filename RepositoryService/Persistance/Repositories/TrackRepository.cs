using DAL;
using Entities.Models;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MusicMonkeyWebApp.Models.Paging;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;

namespace RepositoryService.Persistance.Repositories
{
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Track GetTrackByIdWithEverything(int? id)
        {
            return db.Tracks
                .Include("TrackGenres")
                .Include("Album.AlbumGenres")
                .Include("Album.Artist.ArtistGenres")
                .FirstOrDefault(x => x.Id == id);
        }

        public static PropertyInfo GetProperty<Source>(string PropertyPath)
        {
            try
            {
                if (string.IsNullOrEmpty(PropertyPath))
                    return null;
                string[] Splitter = { "." };
                string[] SourceProperties = PropertyPath.Split(Splitter, StringSplitOptions.None);
                Type PropertyType = typeof(Source);
                PropertyInfo PropertyInfo = PropertyType.GetProperty(SourceProperties[0]);
                PropertyType = PropertyInfo.PropertyType;
                for (int x = 1; x < SourceProperties.Length; ++x)
                {
                    PropertyInfo = PropertyType.GetProperty(SourceProperties[x]);
                    PropertyType = PropertyInfo.PropertyType;
                }
                return PropertyInfo;
            }
            catch { throw; }
        }

        public IEnumerable<Track> GetTracksWithEverything_OLD(PagingModel pagingModel = null, string orderPropertyName = null)
        {
            if (pagingModel == null)
            {
                return db.Tracks
                .Include("TrackGenres")
                .Include("Album.AlbumGenres")
                .Include("Album.Artist.ArtistGenres")
                .ToList();
            }
            else
            {
                var propInfo = orderPropertyName == null ? null : typeof(Track).GetProperty(orderPropertyName);

                if (propInfo != null)
                {
                    return db.Tracks
                    .Include("TrackGenres")
                    .Include("Album.AlbumGenres")
                    .Include("Album.Artist.ArtistGenres")
                    .ToList()
                    .OrderBy(o => propInfo.GetValue(o, null))
                    .Skip(pagingModel.ItemsPerPage * pagingModel.PageIndex)
                    .Take(pagingModel.ItemsPerPage);
                }
                else
                {
                    return db.Tracks
                    .Include("TrackGenres")
                    .Include("Album.AlbumGenres")
                    .Include("Album.Artist.ArtistGenres")
                    .ToList()
                    .Skip(pagingModel.ItemsPerPage * pagingModel.PageIndex)
                    .Take(pagingModel.ItemsPerPage);
                }
            }
        }


        public IEnumerable<Track> GetTracksWithEverything(PagingModel pagingModel = null, string orderPropertyName = null, string titleFilter = null)
        {
            //, string titleFilter = null

            var tracks = db.Tracks
                .Include("TrackGenres")
                .Include("Album.AlbumGenres")
                .Include("Album.Artist.ArtistGenres")
                .ToList();

            if (!string.IsNullOrWhiteSpace(titleFilter))
            {
                tracks = new List<Track>(tracks.Where(o => o.Title.ToLower().Contains(titleFilter.ToLower())));
            }

            if (!string.IsNullOrWhiteSpace(orderPropertyName))
            {
                var propInfo = typeof(Track).GetProperty(orderPropertyName);
                if (propInfo != null) tracks = new List<Track>(tracks.OrderBy(o => propInfo.GetValue(o, null)));
            }

            if (pagingModel != null)
            {
                tracks = new List<Track>(tracks.Skip(pagingModel.ItemsPerPage * pagingModel.PageIndex).Take(pagingModel.ItemsPerPage));
            }

            return tracks;
        }
    }
}
