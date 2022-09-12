﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Core.Repositories
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        IEnumerable<Album> GetAlbumsWithEverything();
        Album GetAlbumByIdWithEverything(int? id);
    }
}
