﻿using Blogizm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Interfaces
{
    public interface IBlogCategoryRepository
    {
        Task<List<BlogCategory>> GetAllBlogWithCategories();
    }
}
