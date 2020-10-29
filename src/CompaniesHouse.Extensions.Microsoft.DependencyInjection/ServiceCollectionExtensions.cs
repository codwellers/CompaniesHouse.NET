﻿
using System;
using System.Net.Http;
using CompaniesHouse;
using CompaniesHouse.DelegatingHandlers;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions to adding companies house client to the service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="baseUri">The Base Uri of the API</param>        
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, Uri baseUri, string apiKey)
        {
            services.AddTransient(provider => new CompaniesHouseAuthorizationHandler(apiKey));

            services.AddHttpClient<ICompaniesHouseClient, CompaniesHouseClient>(cfg => cfg.BaseAddress = baseUri)
                .AddHttpMessageHandler<CompaniesHouseAuthorizationHandler>();

            services.AddTransient<ICompaniesHouseSearchCompanyClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseSearchOfficerClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseSearchDisqualifiedOfficerClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseSearchAllClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseCompanyProfileClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseCompanyFilingHistoryClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseOfficersClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseCompanyInsolvencyInformationClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseAppointmentsClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHouseDocumentMetadataClient>(provider => provider.GetService<ICompaniesHouseClient>());
            services.AddTransient<ICompaniesHousePersonsWithSignificantControlClient>(provider => provider.GetService<ICompaniesHouseClient>());
            
            return services;
        }
        
        /// <summary>
        /// Registers the companies house client
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="apiKey">The Api Key</param>        
        /// <returns>Service collection</returns>
        public static IServiceCollection AddCompaniesHouseClient(this IServiceCollection services, string apiKey)
        {
            return services.AddCompaniesHouseClient(CompaniesHouseUris.Default, apiKey);
        }

    }
}