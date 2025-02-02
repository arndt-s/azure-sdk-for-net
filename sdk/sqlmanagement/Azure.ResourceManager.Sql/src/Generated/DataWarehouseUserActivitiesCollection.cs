// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="DataWarehouseUserActivitiesResource" /> and their operations.
    /// Each <see cref="DataWarehouseUserActivitiesResource" /> in the collection will belong to the same instance of <see cref="SqlDatabaseResource" />.
    /// To get a <see cref="DataWarehouseUserActivitiesCollection" /> instance call the GetDataWarehouseUserActivities method from an instance of <see cref="SqlDatabaseResource" />.
    /// </summary>
    public partial class DataWarehouseUserActivitiesCollection : ArmCollection, IEnumerable<DataWarehouseUserActivitiesResource>, IAsyncEnumerable<DataWarehouseUserActivitiesResource>
    {
        private readonly ClientDiagnostics _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics;
        private readonly DataWarehouseUserActivitiesRestOperations _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient;

        /// <summary> Initializes a new instance of the <see cref="DataWarehouseUserActivitiesCollection"/> class for mocking. </summary>
        protected DataWarehouseUserActivitiesCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DataWarehouseUserActivitiesCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DataWarehouseUserActivitiesCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", DataWarehouseUserActivitiesResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DataWarehouseUserActivitiesResource.ResourceType, out string dataWarehouseUserActivitiesDataWarehouseUserActivitiesApiVersion);
            _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient = new DataWarehouseUserActivitiesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, dataWarehouseUserActivitiesDataWarehouseUserActivitiesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabaseResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabaseResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataWarehouseUserActivitiesResource>> GetAsync(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Get");
            scope.Start();
            try
            {
                var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivitiesResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataWarehouseUserActivitiesResource> Get(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Get");
            scope.Start();
            try
            {
                var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivitiesResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities
        /// Operation Id: DataWarehouseUserActivities_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataWarehouseUserActivitiesResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataWarehouseUserActivitiesResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DataWarehouseUserActivitiesResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivitiesResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DataWarehouseUserActivitiesResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivitiesResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities
        /// Operation Id: DataWarehouseUserActivities_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataWarehouseUserActivitiesResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataWarehouseUserActivitiesResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DataWarehouseUserActivitiesResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivitiesResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DataWarehouseUserActivitiesResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivitiesResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(dataWarehouseUserActivityName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(dataWarehouseUserActivityName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataWarehouseUserActivitiesResource>> GetIfExistsAsync(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DataWarehouseUserActivitiesResource>(null, response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivitiesResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataWarehouseUserActivitiesResource> GetIfExists(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DataWarehouseUserActivitiesResource>(null, response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivitiesResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DataWarehouseUserActivitiesResource> IEnumerable<DataWarehouseUserActivitiesResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DataWarehouseUserActivitiesResource> IAsyncEnumerable<DataWarehouseUserActivitiesResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
