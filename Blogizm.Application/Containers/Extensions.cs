using Blogizm.Application.Features.CQRS.Handlers.AboutBannerHandlers;
using Blogizm.Application.Features.CQRS.Handlers.AboutHandlers;
using Blogizm.Application.Features.CQRS.Handlers.CategoryHandlers;
using Blogizm.Application.Features.CQRS.Handlers.ContactAddressHandlers;
using Blogizm.Application.Features.CQRS.Handlers.SocialMediaHandlers;
using Blogizm.Application.Features.CQRS.Handlers.TagHandlers;
using Blogizm.Application.Interfaces;
using Blogizm.Application.Services;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogizm.Application.Containers
{
    public static class Extensions
    {
        public static void ContainerDependecies(this IServiceCollection services)
        {

           
            //About
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            //About Banner
            services.AddScoped<GetAboutBannerQueryHandler>();
            services.AddScoped<GetAboutBannerByIdQueryHandler>();
            services.AddScoped<RemoveAboutBannerCommandHandler>();
            services.AddScoped<CreateAboutBannerCommandHandler>();
            services.AddScoped<UpdateAboutBannerCommandHandler>();
            //Author
            services.AddScoped<GetAuthorQueryHandler>();
            services.AddScoped<GetAuthorByIdQueryHandler>();
            services.AddScoped<RemoveAuthorCommandHandler>();
            services.AddScoped<CreateAuthorCommandHandler>();
            services.AddScoped<UpdateAuthorCommandHandler>();
            //Client
            services.AddScoped<GetClientQueryHandler>();
            services.AddScoped<GetClientByIdQueryHandler>();
            services.AddScoped<RemoveClientCommandHandler>();
            services.AddScoped<CreateClientCommandHandler>();
            services.AddScoped<UpdateClientCommandHandler>();

            //ContactAddress
            services.AddScoped<GetContactAddressQueryHandler>();
            services.AddScoped<GetContactAddressByIdQueryHandler>();
            services.AddScoped<RemoveContactAddressCommandHandlerr>();
            services.AddScoped<CreateContactAddressCommandHandler>();
            services.AddScoped<UpdateContactAddressCommandHandler>();
            //Social Media
            services.AddScoped<GetSocialMediaQueryHandler>();
            services.AddScoped<GetSocialMediaByIdQueryHandler>();
            services.AddScoped<RemoveSocialMediaCommandHandler>();
            services.AddScoped<CreateSocialMediaCommandHandler>();
            services.AddScoped<UpdateSocialMediaCommandHandler>();
            //Tag
            services.AddScoped<GetTagQueryHandler>();
            services.AddScoped<GetTagByIdQueryHandler>();
            services.AddScoped<RemoveTagCommandHandler>();
            services.AddScoped<CreateTagCommandHandler>();
            services.AddScoped<UpdateTagCommandHandler>();
            //Category
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();


        }
    }
}
