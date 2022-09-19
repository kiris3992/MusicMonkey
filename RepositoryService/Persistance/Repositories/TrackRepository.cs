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

namespace RepositoryService.Persistance.Repositories
{
    public class TrackRepository:GenericRepository<Track>, ITrackRepository
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

        public IEnumerable<Track> GetTracksWithEverything(PagingModel pagingModel = null)
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
}
