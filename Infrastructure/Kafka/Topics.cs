namespace Common.Infrastructure.Kafka;

public static class Topics
{
    /// <summary>
    /// Static class containing Kafka topics for various services.
    /// </summary>
    public static class ImportProvider
    {
        public const string ImportProviderFinalizerConsumerGroup = "import-provider-finalize-service";
        public const string ImportProviderConsumerGroup = "import-provider-service";
        public const string WantsCreateImportProviderRequestTopic = "wants-create-import-provider";
        public const string FinalizedCreateImportProviderResponseTopic = "finalized-create-import-provider";
        public const string CompletedCreateImportProviderTopic = "completed-create-import-provider";
        public const string WantsUpdateImportProviderRequestTopic = "wants-update-import-provider";
        public const string FinalizedUpdateImportProviderResponseTopic = "finalized-update-import-provider";
        public const string CompletedUpdateImportProviderTopic = "completed-update-import-provider";
        public const string WantsGetImportProvidersRequestTopic = "wants-get-import-providers";
        public const string FinalizedGetImportProvidersResponseTopic = "finalized-get-import-providers";
        public const string CompletedGetImportProvidersTopic = "completed-get-import-providers";
        public const string WantsDeleteImportProviderRequestTopic = "wants-delete-import-provider";
        public const string CompletedDeleteImportProviderTopic = "completed-delete-import-provider";
        public const string FinalizedDeleteImportProviderResponseTopic = "finalized-delete-import-provider";
        public const string WantsGetImportProviderRequestTopic = "wants-get-import-provider";
        public const string FinalizedGetImportProviderResponseTopic = "finalized-get-import-provider";
        public const string CompletedGetImportProviderTopic = "completed-get-import-provider";
        public const string WantsPatchUpdateImportProviderRequestTopic = "wants-patch-update-import-provider";
        public const string FinalizedPatchUpdateImportProviderResponseTopic = "finalized-patch-update-import-provider";
        public const string CompletedPatchUpdateImportProviderTopic = "completed-patch-update-import-provider";

        //Import Provider Configuration Topics

        //WantsRetrieveConfigurationsForTenantRequestTopic
        public const string WantsRetrieveConfigurationsForTenantRequestTopic = "wants-retrieve-configurations-for-tenant";
        public const string FinalizedRetrieveConfigurationsForTenantResponseTopic = "finalized-retrieve-configurations-for-tenant";
        public const string CompletedRetrieveConfigurationsForTenantTopic = "completed-retrieve-configurations-for-tenant";

        //Retrieve
        public const string WantsRetrieveConfigurationsForProviderRequestTopic = "wants-retrieve-configurations-for-provider";
        public const string FinalizedRetrieveConfigurationsForProviderResponseTopic = "finalized-retrieve-configurations-for-provider";
        public const string CompletedRetrieveConfigurationsForProviderTopic = "completed-retrieve-configurations-for-provider";

        //Create
        public const string WantsCreateConfigurationForProviderRequestTopic = "wants-create-configuration-for-provider";
        public const string FinalizedCreateConfigurationForProviderResponseTopic = "finalized-create-configuration-for-provider";
        public const string CompletedCreateConfigurationForProviderTopic = "completed-create-configuration-for-provider";

        //Update
        public const string WantsUpdateConfigurationForProviderRequestTopic = "wants-update-configuration-for-provider";
        public const string FinalizedUpdateConfigurationForProviderResponseTopic = "finalized-update-configuration-for-provider";
        public const string CompletedUpdateConfigurationForProviderTopic = "completed-update-configuration-for-provider";

        //Delete
        public const string WantsDeleteConfigurationForProviderRequestTopic = "wants-delete-configuration-for-provider";
        public const string FinalizedDeleteConfigurationForProviderResponseTopic = "finalized-delete-configuration-for-provider";
        public const string CompletedDeleteConfigurationForProviderTopic = "completed-delete-configuration-for-provider";

        //Patch
        public const string WantsPatchConfigurationForProviderRequestTopic = "wants-patch-configuration-for-provider";
        public const string FinalizedPatchConfigurationForProviderResponseTopic = "finalized-patch-configuration-for-provider";
        public const string CompletedPatchConfigurationForProviderTopic = "completed-patch-configuration-for-provider";
    }

    public static class Tenant
    {
        public const string WantsValidateTenantsRequestTopic = "wants-validate-tenants";
        public const string CompletedValidateTenantsResponseTopic = "completed-validate-tenants";
        public const string FinalizedValidateTenantsResponseTopic = "finalized-validate-tenants";
        public const string WantsGenerateTenantRequestTopic = "wants-generate-tenant";
        public const string CompletedGenerateTenantTopic = "completed-generate-tenant";
        public const string FinishedGenerateTenantResponseTopic = "finished-generate-tenant";
        public const string WantsGetTenantsTopic = "wants-get-tenants";
        public const string WantsGetTenantTopic = "wants-get-tenant";
        public const string WantsGetTenantByExternalIdTopic = "wants-get-tenant-by-external-id";
        public const string CompletedGetTenantsTopic = "completed-get-tenants";
        public const string CompletedGetTenantTopic = "completed-get-tenant";
        public const string CompletedGetTenantByExternalIdTopic = "completed-get-tenant-by-external-id";
        public const string FinalizedGetTenantsTopic = "finalized-get-tenants";
        public const string FinalizedGetTenantByExternalIdTopic = "finalized-get-tenant-by-external-id";
        public const string FinalizedGetTenantTopic = "finalized-get-tenant";
        public const string TenantConsumerGroup = "tenant-service";
        public const string WantsLoginTenantTopic = "wants-login-tenant";
        public const string CompletedLoginTenantTopic = "completed-login-tenant";
        public const string FinalizedLoginTenantTopic = "finalized-login-tenant";
        public const string WantsDeleteTenantRequestTopic = "wants-delete-tenant";
        public const string CompletedDeleteTenantRequestTopic = "completed-delete-tenant";
    }

    public static class PropertyManagement
    {
        //-----------------------------------------------------------------------------------------------
        public const string WantsCreatePropertyAndTenantLinkRequestTopic = "wants-create-property-to-tenant-link";
        public const string FinalizedCreatePropertyAndTenantLinkResponseTopic = "finalized-create-property-to-tenant-link";
        public const string CompletedCreatePropertyAndTenantLinkResponseTopic = "completed-create-property-to-tenant-link";
        //-----------------------------------------------------------------------------------------------
        public const string WantsUpdatePropertyAndTenantLinkRequestTopic = "wants-update-property-to-tenant-link";
        public const string CompletedUpdatePropertyAndTenantLinkResponseTopic = "completed-update-property-to-tenant-link";
        public const string FinalizedUpdatePropertyAndTenantLinkResponseTopic = "finalized-update-property-to-tenant-link";
        //-----------------------------------------------------------------------------------------------
        public const string WantsPatchPropertyAndTenantLinkRequestTopic = "wants-patch-property-to-tenant-link";
        public const string CompletedPatchPropertyAndTenantLinkResponseTopic = "completed-patch-property-to-tenant-link";
        public const string FinalizedPatchPropertyAndTenantLinkResponseTopic = "finalized-patch-property-to-tenant-link";
        //-----------------------------------------------------------------------------------------------
        public const string WantsDeletePropertyAndTenantLinkRequestTopic = "wants-delete-property-to-tenant-link-value";
        public const string CompletedDeletePropertyAndTenantLinkResponseTopic = "completed-delete-property-to-tenant-link-value";
        public const string FinalizedDeletePropertyAndTenantLinkTopic = "finalized-delete-property-to-tenant-link-value";
        //-----------------------------------------------------------------------------------------------
        public const string WantsGetPropertyAndTenantLinksRequestTopic = "wants-get-property-to-tenant-link";
        public const string CompletedGetPropertyAndTenantLinkResponseTopic = "completed-get-property-to-tenant-link";
        public const string FinalizedGetPropertyAndTenantLinkResponseTopic = "finalized-get-property-to-tenant-link";
        //-----------------------------------------------------------------------------------------------
        public const string WantsRetrievePropertiesForUserRequestTopic = "wants-get-properties";
        public const string CompletedRetrievePropertiesForUserResponseTopic = "completed-get-properties";
        public const string FinalizedRetrievePropertiesForUserResponseTopic = "finalized-get-properties";
        //-----------------------------------------------------------------------------------------------
        public const string WantsRetrievePropertiesForTenantRequestTopic = "wants-get-properties-for-tenant";
        public const string CompletedRetrievePropertiesForTenantResponseTopic = "completed-get-properties-for-tenant";
        public const string FinalizedRetrievePropertiesForTenantResponseTopic = "finalized-get-properties-for-tenant";
        //-----------------------------------------------------------------------------------------------
        public const string WantsRetrieveInActivePropertiesRequestTopic = "wants-get-inactive-properties";
        public const string CompletedRetrieveInActivePropertiesResponseTopic = "completed-get-inactive-properties";
        public const string FinalizedRetrieveInActivePropertiesResponseTopic = "finalized-get-inactive-properties";

        //-----------------------------------------------------------------------------------------------
        public const string PropertyManagementConsumerGroup = "property-management-service-value";
        //-----------------------------------------------------------------------------------------------

        public const string WantsBulkImportPropertiesRequestTopic = "wants-bulk-import-properties";
        public const string CompletedBulkImportPropertiesResponseTopic = "completed-bulk-import-properties";
        public const string FinishedBulkImportPropertiesResponseTopic = "finished-bulk-import-properties";
        //-----------------------------------------------------------------------------------------------
        public const string WantsAssignUnassignPropertiesToTenantRequestTopic = "wants-assign-unassign-properties-to-tenant";
        public const string CompletedAssignUnassignPropertiesToTenantResponseTopic = "completed-assign-unassign-properties-to-tenant";
        public const string FinishedAssignUnassignPropertiesToTenantResponseTopic = "finished-assign-unassign-properties-to-tenant";
        //-----------------------------------------------------------------------------------------------
        public const string WantsRetrievePropertyRequestTopic = "wants-retrieve-property";
        public const string CompletedRetrievePropertyResponseTopic = "completed-retrieve-property";
        public const string FinishedRetrievePropertyResponseTopic = "finished-retrieve-property";
        //-----------------------------------------------------------------------------------------------
        public const string WantsDeletePropertyRequestTopic = "wants-delete-property";
        public const string CompletedDeletePropertyResponseTopic = "completed-delete-property";
        public const string FinishedDeletePropertyResponseTopic = "finished-delete-property";
        //-----------------------------------------------------------------------------------------------
        public const string WantsPatchPropertyRequestTopic = "wants-patch-property";
        public const string CompletedPatchPropertyResponseTopic = "completed-patch-property";
        public const string FinishedPatchPropertyResponseTopic = "finished-patch-property";
        //-----------------------------------------------------------------------------------------------
        public const string WantsActivateDeactivatePropertyRequestTopic = "wants-activate-deactivate-property";
        public const string CompletedActivateDeactivatePropertyResponseTopic = "completed-activate-deactivate-property";
        public const string FinishedActivateDeactivatePropertyResponseTopic = "finished-activate-deactivate-property";
        //-----------------------------------------------------------------------------------------------
        public const string WantsCreatePropertyRequestTopic = "wants-create-property";
        public const string CompletedCreatePropertyResponseTopic = "completed-create-property";
        //-----------------------------------------------------------------------------------------------
        public const string WantsImportPropertySettingRequestTopic = "wants-import-property-setting";
        public const string CompletedImportPropertySettingResponseTopic = "completed-import-property-setting";

        public const string WantsCreatePropertyManuallyRequestTopic = "wants-import-property-manually-setting";
        public const string CompletedCreatePropertyManuallyResponseTopic = "completed-import-property-manually-setting";
    }

    public static class AnomalyDetection
    {
        public const string WantsHandleAnomalyDetectionResponseTopic = "wants-handle-anomaly-detecrion-response-value";
        public const string FinalizedHandleAnomalyDetectionResponseTopic = "finalized-handle-anomaly-detecrion-response-value";
        public const string CompletedHandleAnomalyDetectionResponseTopic = "completed-handle-anomaly-detecrion-response-value";
        public const string WantsGetAnomalyDetectionResponseTopic = "wants-get-anomaly-detecrion-response-value";
        public const string FinalizedGetAnomalyDetectionResponseTopic = "finalized-get-anomaly-detecrion-response-value";
        public const string CompletedGetAnomalyDetectionResponseTopic = "completed-get-anomaly-detecrion-response-value";
        public const string AnomalyDetectionConsumerGroup = "anomaly-detection-service-value";
    }

    public static class User
    {
        public const string WantsCreateUserRequestTopic = "wants-create-user";
        public const string CompletedCreateUserTopic = "completed-create-user";
        public const string FinalizedCreateUserResponseTopic = "finalized-create-user";
        public const string WantsGetKeycloakUsersTopic = "wants-keycloak-get-users";
        public const string CompletedGetKeycloakUsersTopic = "completed-keycloak-get-users";
        public const string FinalizedGetKeycloakUsersTopic = "finalized-keycloak-get-users";
        public const string UsersConsumerGroup = "users-service";
        public const string GroupsConsumerGroup = "groups-service";
        public const string WantsEditUserTopic = "wants-edit-user-value";
        public const string CompletedEditUserTopic = "completed-edit-user-value";
        public const string FinalizedEditUserTopic = "finalized-edit-user-value";

        // Groups
        public const string WantsGetGroupsTopic = "wants-get-groups";
        public const string CompletedGetGroupsTopic = "completed-get-groups";
        public const string FinalizedGetGroupsTopic = "finalized-get-groups";
        public const string WantsGetUserAssignedPropertiesFromGroupsTopic = "wants-get-user-assigned-properties-from-groups";
        public const string CompletedGetUserAssignedPropertiesFromGroupsTopic = "completed-get-user-assigned-properties-from-groups";
        public const string FinalizedGetUserAssignedPropertiesFromGroupsTopic = "finalized-get-user-assigned-properties-from-groups";
        public const string WantsCreateGroupTopic = "wants-create-group";
        public const string CompletedCreateGroupTopic = "completed-create-group";
        public const string FinalizedCreateGroupTopic = "finalized-create-group";
        public const string WantsUpdateGroupTopic = "wants-update-group";
        public const string CompletedUpdateGroupTopic = "completed-update-group";
        public const string FinalizedUpdateGroupTopic = "finalized-update-group";
        public const string WantsDeleteGroupTopic = "wants-delete-group";
        public const string CompletedDeleteGroupTopic = "completed-delete-group";
        public const string FinalizedDeleteGroupTopic = "finalized-delete-group";
        public const string WantsDeleteGroupByTenantTopic = "wants-delete-group-by-tenant";

    }

    public static class ApiKeys
    {
        public const string ApiKeyConsumerGroup = "api-key-service";
        public const string WantsGenerateApiKeyRequestTopic = "wants-generate-api-key";
        public const string FinalizedGenerateApiKeyResponseTopic = "finalized-generate-api-key";
        public const string CompletedGenerateApiKeyTopic = "completed-generate-api-key";
        public const string WantsUpdateApiKeyRequestTopic = "wants-update-api-key";
        public const string FinalizedUpdateApiKeyResponseTopic = "finalized-update-api-key";
        public const string CompletedUpdateApiKeyTopic = "completed-update-api-key";
        public const string WantsGetApiKeysRequestTopic = "wants-get-api-keys";
        public const string FinalizedGetApiKeysResponseTopic = "finalized-get-api-keys";
        public const string CompletedGetApiKeysTopic = "completed-get-api-keys";
        public const string WantsDeleteApiKeyRequestTopic = "wants-delete-api-key";
        public const string CompletedDeleteApiKeyTopic = "completed-delete-api-key";
        public const string FinalizedDeleteApiKeyResponseTopic = "finalized-delete-api-key";
        public const string WantsGetApiKeyRequestTopic = "wants-get-api-key";
        public const string FinalizedGetApiKeyResponseTopic = "finalized-get-api-key";
        public const string CompletedGetApiKeyTopic = "completed-get-api-key";
        public const string WantsDeleteApiKeyByTenant = "wants-delete-api-key-by-tenant";


        //api key validation
        public const string FinalizedValidateApiKeyResponseTopic = "finalized-validate-api-key";
        public const string CompletedValidateApiKeyTopic = "completed-validate-api-key";
        public const string WantsValidateApiKeyRequestTopic = "wants-validate-api-key";

    }

    public static class ImportData
    {
        public const string ImportDataFinalizerConsumerGroup = "import-data-finalize-service";
        public const string DataImportConsumerGroup = "data-import-service";
        public const string WantsCreateImportDataRequestTopic = "wants-create-import-data";
        public const string FinalizedCreateImportDataResponseTopic = "finalized-create-impor-data";
        public const string CompletedCreateImportDataTopic = "completed-create-import-data";

        public const string WantsImportDataRequestTopic = "wants-import-data";
        public const string FinalizedImportDataResponseTopic = "finalized-import-data";
        public const string CompletedImportDataTopic = "completed-import-data";

        public const string WantsGetWeeklyBookingDataTopic = "wants-get-weekly-booking-data";
        public const string CompletedGetWeeklyBookingDataTopic = "completed-get-weekly-booking-data";
        public const string FinalizedGetWeeklyBookingDataTopic = "finalized-get-weekly-booking-data";


        public const string WantsAddImportStateRequestTopic = "wants-add-import-data-state";



        public const string WantsRetrievePMSDatasRequestTopic = "wants-retrieve-pms-datas";
        public const string FinalizedRetrievePMSDatasReponseTopic = "finalized-retrieve-pms-datas";
        public const string CompletedRetrievePMSDatasTopic = "completed-retrieve-pms-datas";

        public const string WantsDeleteImportDataByTenant = "wants-delete-import-data-by-tenant";
    }

    public static class ImportState
    {
        public const string ImportStateFinalizerConsumerGroup = "import-state-finalize-service";
        public const string ImportStateConsumerGroup = "import-state-service";
        public const string WantsRetrieveImportStateRequestTopic = "wants-retrieve-import-state";
        public const string FinalizedRetrieveImportStateReponseTopic = "finalized-retrieve-import-state";
        public const string CompletedRetrieveImportStateTopic = "completed-retrieve-import-state";
    }

    public static class WeatherProvider
    {
        public const string WeatherProviderConsumerGroup = "weather-provider-service";

        // Weather Provider Configurations Topic
        public const string WantsCreateWeatherProviderConfigurationRequestTopic = "wants-create-weather-provider-configuration";
        public const string FinalizedCreateWeatherProviderConfigurationReponseTopic = "finalized-create-weather-provider-configuration";
        public const string CompletedCreateWeatherProviderConfigurationTopic = "completed-create-weather-provider-configuration";

        public const string WantsDeleteWeatherProviderConfigurationRequestTopic = "wants-delete-weather-provider-configuration";
        public const string FinalizedDeleteWeatherProviderConfigurationReponseTopic = "finalized-delete-weather-provider-configuration";
        public const string CompletedDeleteWeatherProviderConfigurationTopic = "completed-delete-weather-provider-configuration";

        public const string WantsRetrieveWeatherProviderConfigurationRequestTopic = "wants-retrieve-weather-provider-configuration";
        public const string FinalizedRetrieveWeatherProviderConfigurationReponseTopic = "finalized-retrieve-weather-provider-configuration";
        public const string CompletedRetrieveWeatherProviderConfigurationTopic = "completed-retrieve-weather-provider-configuration";

        public const string WantsRetrieveWeatherProviderConfigurationsRequestTopic = "wants-retrieve-weather-provider-configurations";
        public const string FinalizedRetrieveWeatherProviderConfigurationsReponseTopic = "finalized-retrieve-weather-provider-configurations";
        public const string CompletedRetrieveWeatherProviderConfigurationsTopic = "completed-retrieve-weather-provider-configurations";

        public const string WantsUpdateWeatherProviderConfigurationRequestTopic = "wants-update-weather-provider-configuration";
        public const string FinalizedUpdateWeatherProviderConfigurationReponseTopic = "finalized-update-weather-provider-configuration-value";
        public const string CompletedUpdateWeatherProviderConfigurationTopic = "completed-update-weather-provider-configuration-value";

        // Weather Providers Topic
        public const string WantsRetrieveWeatherDataRequestTopic = "wants-retrieve-weather-data";
        public const string FinalizedRetrieveWeatherDataReponseTopic = "finalized-retrieve-weather-data";
        public const string CompletedRetrieveWeatherDataTopic = "completed-retrieve-weather-data";

        public const string WantsRetrieveWeatherProvidersRequestTopic = "wants-retrieve-weather-providers";
        public const string FinalizedRetrieveWeatherProvidersReponseTopic = "finalized-retrieve-weather-providers";
        public const string CompletedRetrieveWeatherProvidersTopic = "completed-retrieve-weather-providers";

        public const string WantsDeleteWetherDataByTenantTopic = "wants-delete-weather-data-by-tenant";
    }

    public static class WeatherProviderApp
    {
        public const string WeatherProviderServiceAppConsumerGroup = "weather-provider-service-app-value";

        public const string WantsRegisterWeatherProviderRequestTopic = "wants-register-weather-provider-value";
        public const string WantsDeregisterWeatherProviderRequestTopic = "wants-deregister-weather-provider-value";

    }

    public static class WeatherData
    {
        public const string WeatherProviderDataServiceConsumerGroup = "weather-provider-data-service";

        public const string WantsRetrieveWeatherDataForRegionRequestTopic = "wants-retrieve-weather-data-for-region";
        public const string FinalizedRetrieveWeatherDataForRegionReponseTopic = "finalized-retrieve-weather-data-for-region-value-value-value-value";
        public const string CompletedRetrieveWeatherDataForRegionTopic = "completed-retrieve-weather-data-for-region-value-value-value-value";

        public const string WantsStoreWeatherDataForRegionRequestTopic = "wants-store-weather-data-for-region-value-value";
        public const string FinalizedStoreWeatherDataForRegionReponseTopic = "finalized-store-weather-data-for-region-value";
        public const string CompletedStoreWeatherDataForRegionTopic = "completed-store-weather-data-for-region-value";
        public const string WantsStoreWeatherDataForLocationsTopic = "wants-store-weather-data-for-locations";
        public const string WantsRetrieveWeatherDataForLocationTopic = "wants-retrieve-weather-data-for-location";
        public const string FinalizedRetrieveWeatherDataForLocationReponseTopic = "finalized-retrieve-weather-data-for-location";
        public const string CompletedRetrieveWeatherDataForLocationTopic = "completed-retrieve-weather-data-for-location";
        public const string WantsRetrieveWeatherForecastForLocationTopic = "wants-retrieve-weather-forecast-for-location";
        public const string FinalizedRetrieveWeatherForecastForLocationReponseTopic = "finalized-retrieve-weather-forecast-for-location";
        public const string CompletedRetrieveWeatherForecastForLocationTopic = "completed-retrieve-weather-forecast-for-location";

        public const string WantsUpdateWeatherInformationByCronRequestTopic = "wants-update-weather-information-by-cron";
    }

    public static class City
    {
        public const string CityConsumerGroup = "city-service";
        public const string WantsCreateCityRequestTopic = "wants-create-city";
        public const string FinalizedCreateCityResponseTopic = "finalized-create-city";
        public const string CompletedCreateCityResponseTopic = "completed-create-city";
        public const string WantsUpdateCityRequestTopic = "wants-update-city";
        public const string FinalizedUpdateCityResponseTopic = "finalized-update-city";
        public const string CompletedUpdateCityResponseTopic = "completed-update-city";
        public const string WantsDeleteCityRequestTopic = "wants-delete-city";
        public const string FinalizedDeleteCityResponseTopic = "finalized-delete-city";
        public const string CompletedDeleteCityResponseTopic = "completed-delete-city";
        public const string WantsGetCityRequestTopic = "wants-get-city";
        public const string FinalizedGetCityResponseTopic = "finalized-get-city";
        public const string CompletedGetCityResponseTopic = "completed-get-city";
        public const string WantsGetCitiesRequestTopic = "wants-get-cities";
        public const string FinalizedGetCitiesResponseTopic = "finalized-get-cities";
        public const string CompletedGetCitiesResponseTopic = "completed-get-cities";
    }

    public static class Continent
    {
        public const string ContinentConsumerGroup = "continent-service";
        public const string WantsCreateContinentRequestTopic = "wants-create-continent";
        public const string FinalizedCreateContinentResponseTopic = "finalized-create-continent";
        public const string CompletedCreateContinentResponseTopic = "completed-create-continent";
        public const string WantsUpdateContinentRequestTopic = "wants-update-continent";
        public const string FinalizedUpdateContinentResponseTopic = "finalized-update-continent";
        public const string CompletedUpdateContinentResponseTopic = "completed-update-continent";
        public const string WantsDeleteContinentRequestTopic = "wants-delete-continent";
        public const string FinalizedDeleteContinentResponseTopic = "finalized-delete-continent";
        public const string CompletedDeleteContinentResponseTopic = "completed-delete-continent";
        public const string WantsGetContinentRequestTopic = "wants-get-continent";
        public const string FinalizedGetContinentResponseTopic = "finalized-get-continent";
        public const string CompletedGetContinentResponseTopic = "completed-get-continent";
        public const string WantsGetContinentsRequestTopic = "wants-get-continents";
        public const string FinalizedGetContinentsResponseTopic = "finalized-get-continents";
        public const string CompletedGetContinentsResponseTopic = "completed-get-continents";
    }

    public static class Country
    {
        //-------------------------------------------------------------------------------------------
        public const string CountryConsumerGroup = "country-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsCreateCountryRequestTopic = "wants-create-country";
        public const string CompletedCreateCountryResponseTopic = "completed-create-country";
        //-------------------------------------------------------------------------------------------
        public const string WantsUpdateCountryRequestTopic = "wants-update-country";
        public const string CompletedUpdateCountryResponseTopic = "completed-update-country";
        //-------------------------------------------------------------------------------------------
        public const string WantsDeleteCountryRequestTopic = "wants-delete-country";
        public const string CompletedDeleteCountryResponseTopic = "completed-delete-country";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetCountryRequestTopic = "wants-get-country";
        public const string CompletedGetCountryResponseTopic = "completed-get-country";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetCountriesRequestTopic = "wants-get-countries";
        public const string CompletedGetCountriesResponseTopic = "completed-get-countries";
        //-------------------------------------------------------------------------------------------
    }

    public static class Region
    {
        //-------------------------------------------------------------------------------------------
        public const string RegionConsumerGroup = "region-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsCreateRegionRequestTopic = "wants-create-region";
        public const string CompletedCreateRegionResponseTopic = "completed-create-region";
        //-------------------------------------------------------------------------------------------
        public const string WantsUpdateRegionRequestTopic = "wants-update-region";
        public const string CompletedUpdateRegionResponseTopic = "completed-update-region";
        //-------------------------------------------------------------------------------------------
        public const string WantsDeleteRegionRequestTopic = "wants-delete-region";
        public const string CompletedDeleteRegionResponseTopic = "completed-delete-region";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetRegionRequestTopic = "wants-get-region";
        public const string CompletedGetRegionResponseTopic = "completed-get-region";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetRegionsRequestTopic = "wants-get-regions";
        public const string CompletedGetRegionsResponseTopic = "completed-get-regions";
        //-------------------------------------------------------------------------------------------
        public const string WantsImportRegionsRequestTopic = "wants-import-regions";
        public const string CompletedImportRegionsResponseTopic = "completed-import-regions";
        //-------------------------------------------------------------------------------------------
    }

    public static class POI
    {
        public const string POIConsumerGroup = "poi-service";
        public const string WantsCreatePOIRequestTopic = "wants-create-poi";
        public const string FinalizedCreatePOIResponseTopic = "finalized-create-poi";
        public const string CompletedCreatePOIResponseTopic = "completed-create-poi";
        public const string WantsUpdatePOIRequestTopic = "wants-update-poi";
        public const string FinalizedUpdatePOIResponseTopic = "finalized-update-poi";
        public const string CompletedUpdatePOIResponseTopic = "completed-update-poi";
        public const string WantsDeletePOIRequestTopic = "wants-delete-poi";
        public const string FinalizedDeletePOIResponseTopic = "finalized-delete-poi";
        public const string CompletedDeletePOIResponseTopic = "completed-delete-poi";
        public const string WantsGetPOIRequestTopic = "wants-get-poi";
        public const string FinalizedGetPOIResponseTopic = "finalized-get-poi";
        public const string CompletedGetPOIResponseTopic = "completed-get-poi";
        public const string WantsGetPOIsRequestTopic = "wants-get-pois";
        public const string FinalizedGetPOIsResponseTopic = "finalized-get-pois";
        public const string CompletedGetPOIsResponseTopic = "completed-get-pois";
    }

    public static class GeographicalDetails
    {
        public const string WantsCreateGeographicalDetailsRequestTopic = "wants-create-geographical-details";
        public const string CompletedCreateGeographicalDetailsResponseTopic = "completed-create-geographical-details";
        public const string FinalizedCreateGeographicalDetailsResponseTopic = "finalized-create-geographical-details";
        public const string WantsGetGeographicalDetailsRequestTopic = "wants-get-geographical-details";
        public const string CompletedGetGeographicalDetailsResponseTopic = "completed-get-geographical-details";
        public const string FinalizedGetGeographicalDetailsResponseTopic = "finalized-get-geographical-details";
        public const string GeographicalDetailsConsumerGroup = "geographical-details-service";
        public const string WantsUpdateGeographicalDetailsRequestTopic = "wants-update-geographical-details-value";
        public const string WantsDeleteGeographicalDetailsRequestTopic = "wants-delete-geographical-details-value";
    }

    public static class Events
    {
        public const string WantsCreateEventCategoryRequestTopic = "wants-create-event-category";
        public const string CompletedCreateEventCategoryResponseTopic = "completed-create-event-category";
        public const string FinalizedCreateEventCategoryResponseTopic = "finalized-create-event-category";
        public const string WantsGetEventCategoryRequestTopic = "wants-get-event-category";
        public const string CompletedGetEventCategoryResponseTopic = "completed-get-event-category";
        public const string FinalizedGetEventCategoryResponseTopic = "finalized-get-event-category";
        public const string EventConsumerGroup = "event-service";
        public const string WantsUpdateEventCategoryRequestTopic = "wants-update-event-category";
        public const string CompletedUpdateEventCategoryResponseTopic = "completed-update-event-category";
        public const string WantsDeleteEventCategoryRequestTopic = "wants-delete-event-category";
        public const string CompletedDeleteEventCategoryResponseTopic = "completed-delete-event-category";
        public const string WantsCreateEventRequestTopic = "wants-create-event";
        public const string FinalizedCreateEventResponseTopic = "finalized-create-event";
        public const string CompletedCreateEventResponseTopic = "completed-create-event";
        public const string WantsDeleteEventRequestTopic = "wants-delete-event";
        public const string CompletedDeleteEventResponseTopic = "completed-delete-event";
        public const string WantsUpdateEventRequestTopic = "wants-update-event";
        public const string CompletedUpdateEventResponseTopic = "completed-update-event";
        public const string WantsPatchUpdateEventRequestTopic = "wants-patch-update-event";
        public const string CompletedPatchUpdateEventResponseTopic = "completed-patch-update-event";
        public const string WantsGetEventRequestTopic = "wants-get-event";
        public const string FinalizedGetEventResponseTopic = "finalized-get-event";
        public const string CompletedGetEventResponseTopic = "completed-get-event";
        public const string WantsGetEventsRequestTopic = "wants-retreieve-all-events-value";
        public const string FinalizedGetEventsResponseTopic = "finalized-retrieve-all-events-value";
        public const string CompletedGetEventsResponseTopic = "completed-retrieve-all-events-value";

        public const string WantsGetAllEventsRequestTopic = "wants-get-all-events";
        public const string FinalizedGetAllEventsResponseTopic = "finalized-get-all-events";
        public const string CompletedGetAllEventsResponseTopic = "completed-get-all-events";
    }

    public static class Predictions
    {
        public const string WantsRetrieveWeatherPredictionDataByCronJob = "wants-retrieve-weather-prediction-data-by-cron";
        public const string WantsRetrieveEventPredictionDataByCronJob = "wants-retrieve-event-prediction-data-by-cron";
        public const string WantsRetrieveUnifiedPredictionDataByCronJob = "wants-retrieve-unified-prediction-data-by-cron";
        public const string PredictionManagerConsumerGroup = "prediction-manager-consumer-group";
    }

    public static class Dashboards
    {
        //-------------------------------------------------------------------------------------------
        public const string WantsProcessPricingModelEventRequestTopic = "wants-process-pricing-model";
        public const string CompletedProcessPricingModelEventResponseTopic = "completed-process-pricing-model";
        //-------------------------------------------------------------------------------------------

        public const string WantsProcessOccupancyAssistanceModelEventRequestTopic = "wants-process-occupancy-assistance-model";
        public const string CompletedProcessOccupancyAssistanceModelEventResponseTopic = "completed-process-occupancy-assistance-model";
        //-------------------------------------------------------------------------------------------

        public const string WantsProcessAnomalyRegressionModelEventRequestTopic = "wants-process-anomaly-regression-model";
        public const string CompletedProcessAnomalyRegressionModelEventResponseTopic = "completed-process-anomaly-regression-model";
        //-------------------------------------------------------------------------------------------

        public const string DashboardConsumerGroup = "dashboard-service";

    }

    public static class BookedEvent
    {
        public const string BookedEventConsumerGroup = "booked-events-service";
        public const string WantsCreateBookedEventRequestTopic = "wants-create-booked-event";
        public const string CompletedCreateBookedEventTopic = "completed-create-booked-event";
        public const string FinalizedCreateBookedEventResponseTopic = "finalized-create-booked-event";
        public const string WantsGetBookedEventsTopic = "wants-get-booked-events";
        public const string CompletedGetBookedEventsTopic = "completed-get-booked-events";
        public const string FinalizedGetBookedEventsTopic = "finalized-get-booked-events";
        public const string WantsUpdateBookedEventTopic = "wants-update-booked-event";
        public const string CompletedUpdateBookedEventTopic = "completed-update-booked-event";
        public const string FinalizedUpdateBookedEventTopic = "finalized-update-booked-event";
        public const string WantsGetBookedEventTopic = "wants-get-booked-event";
        public const string CompletedGetBookedEventTopic = "completed-get-booked-event";
        public const string FinalizedGetBookedEventTopic = "finalized-get-booked-event";
        public const string WantsDeleteBookedEventTopic = "wants-delete-booked-event";
        public const string CompletedDeleteBookedEventTopic = "completed-delete-booked-event";
        public const string FinalizedDeleteBookedEventTopic = "finalized-delete-booked-event";

    }

    public static class CompetitorHotel
    {
        public const string CompetitorHotelConsumerGroup = "competitor-hotels-service";
        public const string WantsCreateCompetitorHotelRequestTopic = "wants-create-competitor-hotel";
        public const string CompletedCreateCompetitorHotelTopic = "completed-create-competitor-hotel";
        public const string FinalizedCreateCompetitorHotelResponseTopic = "finalized-create-competitor-hotel";
        public const string WantsGetCompetitorHotelsTopic = "wants-get-competitor-hotels";
        public const string CompletedGetCompetitorHotelsTopic = "completed-get-competitor-hotels";
        public const string FinalizedGetCompetitorHotelsTopic = "finalized-get-competitor-hotels";
        public const string WantsUpdateCompetitorHotelTopic = "wants-update-competitor-hotel";
        public const string CompletedUpdateCompetitorHotelTopic = "completed-update-competitor-hotel";
        public const string FinalizedUpdateCompetitorHotelTopic = "finalized-update-competitor-hotel";
        public const string WantsGetCompetitorHotelTopic = "wants-get-competitor-hotel";
        public const string CompletedGetCompetitorHotelTopic = "completed-get-competitor-hotel";
        public const string FinalizedGetCompetitorHotelTopic = "finalized-get-competitor-hotel";
        public const string WantsDeleteCompetitorHotelTopic = "wants-delete-competitor-hotel";
        public const string CompletedDeleteCompetitorHotelTopic = "completed-delete-competitor-hotel";
        public const string FinalizedDeleteCompetitorHotelTopic = "finalized-delete-competitor-hotel";

    }

    public static class RoomConfigurations
    {   //-------------------------------------------------------------------------------------------
        public const string RoomConfigurationsConsumerGroup = "room-configurations-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new room configuration. */
        public const string WantsCreateRoomConfigurationRequestTopic = "wants-create-room-configuration";
        public const string FinalizedCreateRoomConfigurationResponseTopic = "finalized-create-room-configuration";
        public const string CompletedCreateRoomConfigurationResponseTopic = "completed-create-room-configuration";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing room configuration.*/
        public const string WantsUpdateRoomConfigurationRequestTopic = "wants-update-room-configuration";
        public const string FinalizedUpdateRoomConfigurationResponseTopic = "finalized-update-room-configuration";
        public const string CompletedUpdateRoomConfigurationResponseTopic = "completed-update-room-configuration";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a list of room configurations. */
        public const string WantsGetRoomConfigurationsRequestTopic = "wants-get-room-configurations";
        public const string FinalizedGetRoomConfigurationsResponseTopic = "finalized-get-room-configurations";
        public const string CompletedGetRoomConfigurationsResponseTopic = "completed-get-room-configurations";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete an existing room configuration. */
        public const string WantsDeleteRoomConfigurationRequestTopic = "wants-delete-room-configuration";
        public const string CompletedDeleteRoomConfigurationResponseTopic = "completed-delete-room-configuration";
        public const string FinalizedDeleteRoomConfigurationResponseTopic = "finalized-delete-room-configuration";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a specific room configuration. */
        public const string WantsGetRoomConfigurationRequestTopic = "wants-get-room-configuration";
        public const string FinalizedGetRoomConfigurationResponseTopic = "finalized-get-room-configuration";
        public const string CompletedGetRoomConfigurationResponseTopic = "completed-get-room-configuration";
        //-------------------------------------------------------------------------------------------
    }

    public static class PriceLists
    {   //-------------------------------------------------------------------------------------------
        public const string PriceListsConsumerGroup = "price-lists-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a user initiates the creation of a new price list. */
        public const string WantsCreatePriceListRequestTopic = "wants-create-price-list";
        public const string FinalizedCreatePriceListResponseTopic = "finalized-create-price-list";
        public const string CompletedCreatePriceListResponseTopic = "completed-create-price-list";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a user initiates an update to an existing price list.*/
        public const string WantsUpdatePriceListRequestTopic = "wants-update-price-list";
        public const string FinalizedUpdatePriceListResponseTopic = "finalized-update-price-list";
        public const string CompletedUpdatePriceListResponseTopic = "completed-update-price-list";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a list of price list. */
        public const string WantsGetPriceListsRequestTopic = "wants-get-price-lists";
        public const string FinalizedGetPriceListsResponseTopic = "finalized-get-price-lists";
        public const string CompletedGetPriceListsResponseTopic = "completed-get-price-lists";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a user initiates the deletion of an existing price list. */
        public const string WantsDeletePriceListRequestTopic = "wants-delete-price-list";
        public const string CompletedDeletePriceListResponseTopic = "completed-delete-price-list";
        public const string FinalizedDeletePriceListResponseTopic = "finalized-delete-price-list";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a user requests to view the details of an existing price list. */
        public const string WantsGetPriceListRequestTopic = "wants-get-price-list";
        public const string FinalizedGetPriceListResponseTopic = "finalized-get-price-list";
        public const string CompletedGetPriceListResponseTopic = "completed-get-price-list";
        //-------------------------------------------------------------------------------------------
    }
    public static class MealPlans
    {
        //-------------------------------------------------------------------------------------------
        public const string MealPlansConsumerGroup = "meal-plans-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a user initiates the creation of a new meal plan. */
        public const string WantsCreateMealPlanRequestTopic = "wants-create-meal-plan";
        public const string FinalizedCreateMealPlanResponseTopic = "finalized-create-meal-plan";
        public const string CompletedCreateMealPlanResponseTopic = "completed-create-meal-plan";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a user initiates an update to an existing meal plan. */
        public const string WantsUpdateMealPlanRequestTopic = "wants-update-meal-plan";
        public const string FinalizedUpdateMealPlanResponseTopic = "finalized-update-meal-plan";
        public const string CompletedUpdateMealPlanResponseTopic = "completed-update-meal-plan";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a list of meal plans. */
        public const string WantsGetMealPlansRequestTopic = "wants-get-meal-plans";
        public const string FinalizedGetMealPlansResponseTopic = "finalized-get-meal-plans";
        public const string CompletedGetMealPlansResponseTopic = "completed-get-meal-plans";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a user initiates the deletion of an existing meal plan. */
        public const string WantsDeleteMealPlanRequestTopic = "wants-delete-meal-plan";
        public const string CompletedDeleteMealPlanResponseTopic = "completed-delete-meal-plan";
        public const string FinalizedDeleteMealPlanResponseTopic = "finalized-delete-meal-plan";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a user requests to view the details of an existing meal plan. */
        public const string WantsGetMealPlanRequestTopic = "wants-get-meal-plan";
        public const string FinalizedGetMealPlanResponseTopic = "finalized-get-meal-plan";
        public const string CompletedGetMealPlanResponseTopic = "completed-get-meal-plan";
        //-------------------------------------------------------------------------------------------
    }

    public static class ExternalApiKeys
    {
        //-------------------------------------------------------------------------------------------
        public const string ExternalApiKeyConsumerGroup = "external-api-key-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsCreateExternalApiKeyRequestTopic = "wants-generate-external-api-key";
        public const string FinalizedCreateExternalApiKeyResponseTopic = "finalized-generate-external-api-key";
        public const string CompletedCreateExternalApiKeyResponseTopic = "completed-generate-external-api-key";
        //-------------------------------------------------------------------------------------------
        public const string WantsUpdateExternalApiKeyRequestTopic = "wants-update-external-api-key";
        public const string FinalizedUpdateExternalApiKeyResponseTopic = "finalized-update-external-api-key";
        public const string CompletedUpdateExternalApiKeyResponseTopic = "completed-update-external-api-key";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetExternalApiKeysRequestTopic = "wants-get-external-api-keys";
        public const string FinalizedGetExternalApiKeysResponseTopic = "finalized-get-external-api-keys";
        public const string CompletedGetExternalApiKeysResponseTopic = "completed-get-external-api-keys";
        //---------------------------------------------------------------------------------------------
        public const string WantsDeleteExternalApiKeyRequestTopic = "wants-delete-external-api-key";
        public const string CompletedDeleteExternalApiKeyResponseTopic = "completed-delete-external-api-key";
        public const string FinalizedDeleteExternalApiKeyResponseTopic = "finalized-delete-external-api-key";
        //-----------------------------------------------------------------------------------------------
        public const string WantsGetExternalApiKeyRequestTopic = "wants-get-external-api-key";
        public const string FinalizedGetExternalApiKeyResponseTopic = "finalized-get-external-api-key";
        public const string CompletedGetExternalApiKeyResponseTopic = "completed-get-external-api-key";
        //-------------------------------------------------------------------------------------------
        // External API key validation
        public const string FinalizedValidateExternalApiKeyResponseTopic = "finalized-validate-external-api-key";
        public const string CompletedValidateExternalApiKeyResponseTopic = "completed-validate-external-api-key";
        public const string WantsValidateExternalApiKeyRequestTopic = "wants-validate-external-api-key";
        //-------------------------------------------------------------------------------------------
    }
    public static class OfferPackage
    {
        public const string OfferPackageConsumerGroup = "offer-package-service";
        /* Triggered when a request is made to create a new offer package. */
        public const string WantsCreateOfferPackageRequestTopic = "wants-create-offer-package";
        public const string FinalizedCreateOfferPackageResponseTopic = "finalized-create-offer-package";
        public const string CompletedCreateOfferPackageResponseTopic = "completed-create-offer-package";
        /* Triggered when a request is made to update an existing offer package. */
        public const string WantsUpdateOfferPackageRequestTopic = "wants-update-offer-package";
        public const string FinalizedUpdateOfferPackageResponseTopic = "finalized-update-offer-package";
        public const string CompletedUpdateOfferPackageResponseTopic = "completed-update-offer-package";
        /* Triggered when a request is made to retrieve a list of offer packages. */
        public const string WantsGetOfferPackagesRequestTopic = "wants-get-offer-packages";
        public const string FinalizedGetOfferPackagesResponseTopic = "finalized-get-offer-packages";
        public const string CompletedGetOfferPackagesResponseTopic = "completed-get-offer-packages";
        /* Triggered when a request is made to delete an existing offer package. */
        public const string WantsDeleteOfferPackageRequestTopic = "wants-delete-offer-package";
        public const string FinalizedDeleteOfferPackageResponseTopic = "finalized-delete-offer-package";
        public const string CompletedDeleteOfferPackageResponseTopic = "completed-delete-offer-package";
        /* Triggered when a request is made to retrieve a specific offer package. */
        public const string WantsGetOfferPackageRequestTopic = "wants-get-offer-package";
        public const string FinalizedGetOfferPackageResponseTopic = "finalized-get-offer-package";
        public const string CompletedGetOfferPackageResponseTopic = "completed-get-offer-package";

        public const string WantsDeleteOfferPackagesByTenant = "wants-delete-offer-packages-by-tenant";
    }

    public static class ImportHotelInformation
    {


        //-------------------------------------------------------------------------------------------
        public const string SearchHotelInformationConsumerGroup = "search-hotel-information-service";
        //-------------------------------------------------------------------------------------------
        public const string ImportHotelInformationConsumerGroup = "import-hotel-information-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsCreateImportHotelInformationRequestTopic = "wants-create-import-hotel-information";
        public const string FinalizedCreateImportHotelInformationResponseTopic = "finalized-create-import-hotel-information";
        public const string CompletedCreateImportHotelInformationResponseTopic = "completed-create-import-hotel-information";
        //-------------------------------------------------------------------------------------------
        public const string WantsImportHotelInformationRequestTopic = "wants-import-hotel-information";
        public const string FinalizedImportHotelInformationResponseTopic = "finalized-import-hotel-information";
        public const string CompletedImportHotelInformationResponseTopic = "completed-import-hotel-information";
        //-------------------------------------------------------------------------------------------
        public const string WantsSearchHotelInformationRequestTopic = "wants-search-hotel-information";
        public const string FinalizedSearchHotelInformationResponseTopic = "finalized-search-hotel-information";
        public const string CompletedSearchHotelInformationResponseTopic = "completed-search-hotel-information";

        public const string WantsDeleteHotelRoomInformationTopic = "wants-delete-hotel-room-information-by-tenant";
    }

    public static class NotificationContacts
    {
        public const string NotificationContractConsumerGroup = "notification-contract-service";
        public const string WantsCreateNotificationContractRequestTopic = "wants-create-notification-contract";
        public const string FinalizedCreateNotificationContractResponseTopic = "finalized-create-notification-contract";
        public const string CompletedCreateNotificationContractTopic = "completed-create-notification-contract";
        public const string WantsUpdateNotificationContractRequestTopic = "wants-update-notification-contract";
        public const string FinalizedUpdateNotificationContractResponseTopic = "finalized-update-notification-contract";
        public const string CompletedUpdateNotificationContractTopic = "completed-update-notification-contract";
        public const string WantsGetNotificationContractsRequestTopic = "wants-get-notification-contracts";
        public const string FinalizedGetNotificationContractsResponseTopic = "finalized-get-notification-contracts";
        public const string CompletedGetNotificationContractsTopic = "completed-get-notification-contracts";
        public const string WantsDeleteNotificationContractRequestTopic = "wants-delete-notification-contract";
        public const string CompletedDeleteNotificationContractTopic = "completed-delete-notification-contract";
        public const string FinalizedDeleteNotificationContractResponseTopic = "finalized-delete-notification-contract";
        public const string WantsGetNotificationContractRequestTopic = "wants-get-notification-contract";
        public const string FinalizedGetNotificationContractResponseTopic = "finalized-get-notification-contract";
        public const string CompletedGetNotificationContractTopic = "completed-get-notification-contract";

    }
    public static class Hotels
    {
        public const string HotelConsumerGroup = "hotel-service";
        public const string WantsGenerateHotelRequestTopic = "wants-generate-hotel";
        public const string FinalizedGenerateHotelResponseTopic = "finalized-generate-hotel";
        public const string CompletedGenerateHotelTopic = "completed-generate-hotel";
        public const string WantsUpdateHotelRequestTopic = "wants-update-hotel";
        public const string FinalizedUpdateHotelResponseTopic = "finalized-update-hotel";
        public const string CompletedUpdateHotelTopic = "completed-update-hotel";
        public const string WantsGetHotelsRequestTopic = "wants-get-hotels";
        public const string FinalizedGetHotelsResponseTopic = "finalized-get-hotels";
        public const string CompletedGetHotelsTopic = "completed-get-hotels";
        public const string WantsDeleteHotelRequestTopic = "wants-delete-hotel";
        public const string CompletedDeleteHotelTopic = "completed-delete-hotel";
        public const string FinalizedDeleteHotelResponseTopic = "finalized-delete-hotel";
        public const string WantsGetHotelRequestTopic = "wants-get-hotel";
        public const string FinalizedGetHotelResponseTopic = "finalized-get-hotel";
        public const string CompletedGetHotelTopic = "completed-get-hotel";

    }
    public static class RoomInformationContacts
    {
        public const string RoomInformationConsumerGroup = "room-information-service";
        public const string WantsCreateRoomInformationRequestTopic = "wants-create-room-information";
        public const string FinalizedCreateRoomInformationResponseTopic = "finalized-create-room-information";
        public const string CompletedCreateRoomInformationTopic = "completed-create-room-information";
        public const string WantsUpdateRoomInformationRequestTopic = "wants-update-room-information";
        public const string FinalizedUpdateRoomInformationResponseTopic = "finalized-update-room-information";
        public const string CompletedUpdateRoomInformationTopic = "completed-update-room-information";
        public const string WantsGetRoomInformationsRequestTopic = "wants-get-room-informations";
        public const string FinalizedGetRoomInformationsResponseTopic = "finalized-get-room-informations";
        public const string CompletedGetRoomInformationsTopic = "completed-get-room-informations";
        public const string WantsDeleteRoomInformationRequestTopic = "wants-delete-room-information";
        public const string CompletedDeleteRoomInformationTopic = "completed-delete-room-information";
        public const string FinalizedDeleteRoomInformationResponseTopic = "finalized-delete-room-information";
        public const string WantsGetRoomInformationRequestTopic = "wants-get-room-information";
        public const string FinalizedGetRoomInformationResponseTopic = "finalized-get-room-information";
        public const string CompletedGetRoomInformationTopic = "completed-get-room-information";
    }

    public static class Tags
    {
        //-------------------------------------------------------------------------------------------
        public const string TagsConsumerGroup = "tags-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new tag. */
        public const string WantsCreateTagRequestTopic = "wants-create-Tag";
        public const string FinalizedCreateTagResponseTopic = "finalized-create-Tag";
        public const string CompletedCreateTagResponseTopic = "completed-create-Tag";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing tag. */
        public const string WantsUpdateTagRequestTopic = "wants-update-Tag";
        public const string FinalizedUpdateTagResponseTopic = "finalized-update-Tag";
        public const string CompletedUpdateTagResponseTopic = "completed-update-Tag";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all tags. */
        public const string WantsGetTagsRequestTopic = "wants-get-Tags";
        public const string FinalizedGetTagsResponseTopic = "finalized-get-Tags";
        public const string CompletedGetTagsResponseTopic = "completed-get-Tags";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete a tag. */
        public const string WantsDeleteTagRequestTopic = "wants-delete-Tag";
        public const string CompletedDeleteTagResponseTopic = "completed-delete-Tag";
        public const string FinalizedDeleteTagResponseTopic = "finalized-delete-Tag";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific tag by its ID. */
        public const string WantsGetTagRequestTopic = "wants-get-Tag";
        public const string FinalizedGetTagResponseTopic = "finalized-get-Tag";
        public const string CompletedGetTagResponseTopic = "completed-get-Tag";
        //-------------------------------------------------------------------------------------------
    }

    public static class CompetitorData
    {
        //-----------------------------------------------------------------------------------------------
        public const string CompetitorDataConsumerGroup = "competitor-data-service";
        //-----------------------------------------------------------------------------------------------
        public const string WantsCreateCompetitorDataRequestTopic = "wants-create-competitor-data";
        public const string CompletedCreateCompetitorDataTopic = "completed-create-competitor-data";
        public const string FinalizedCreateCompetitorDataResponseTopic = "finalized-create-competitor-data";
        //-----------------------------------------------------------------------------------------------
        public const string WantsGetAllCompetitorDataTopic = "wants-get-all-competitor-data";
        public const string CompletedGetAllCompetitorDataTopic = "completed-get-all-competitor-data";
        public const string FinalizedGetAllCompetitorDataTopic = "finalized-get-all-competitor-data";
        //-----------------------------------------------------------------------------------------------
        public const string WantsUpdateCompetitorDataTopic = "wants-update-competitor-data";
        public const string CompletedUpdateCompetitorDataTopic = "completed-update-competitor-data";
        public const string FinalizedUpdateCompetitorDataTopic = "finalized-update-competitor-data";
        //-----------------------------------------------------------------------------------------------
        public const string WantsGetCompetitorDataTopic = "wants-get-competitor-data";
        public const string CompletedGetCompetitorDataTopic = "completed-get-competitor-data";
        public const string FinalizedGetCompetitorDataTopic = "finalized-get-competitor-data";
        //-----------------------------------------------------------------------------------------------
        public const string WantsDeleteCompetitorDataTopic = "wants-delete-competitor-data";
        public const string CompletedDeleteCompetitorDataTopic = "completed-delete-competitor-data";
        public const string FinalizedDeleteCompetitorDataTopic = "finalized-delete-competitor-data";
        //-----------------------------------------------------------------------------------------------

    }

    public static class TextManagement
    {
        //-------------------------------------------------------------------------------------------
        public const string TextsConsumerGroup = "texts-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new text. */
        public const string WantsCreateTextRequestTopic = "wants-create-Text";
        public const string FinalizedCreateTextResponseTopic = "finalized-create-Text";
        public const string CompletedCreateTextResponseTopic = "completed-create-Text";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing text. */
        public const string WantsUpdateTextRequestTopic = "wants-update-Text";
        public const string FinalizedUpdateTextResponseTopic = "finalized-update-Text";
        public const string CompletedUpdateTextResponseTopic = "completed-update-Text";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all texts. */
        public const string WantsGetTextsRequestTopic = "wants-get-Texts";
        public const string FinalizedGetTextsResponseTopic = "finalized-get-Texts";
        public const string CompletedGetTextsResponseTopic = "completed-get-Texts";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete a text. */
        public const string WantsDeleteTextRequestTopic = "wants-delete-Text";
        public const string CompletedDeleteTextResponseTopic = "completed-delete-Text";
        public const string FinalizedDeleteTextResponseTopic = "finalized-delete-Text";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific text by its ID. */
        public const string WantsGetTextRequestTopic = "wants-get-Text";
        public const string FinalizedGetTextResponseTopic = "finalized-get-Text";
        public const string CompletedGetTextResponseTopic = "completed-get-Text";
        //-------------------------------------------------------------------------------------------
    }

    public static class ImageManagement
    {
        //-------------------------------------------------------------------------------------------
        public const string ImagesConsumerGroup = "images-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new image. */
        public const string WantsCreateImageRequestTopic = "wants-create-image";
        public const string FinalizedCreateImageResponseTopic = "finalized-create-image";
        public const string CompletedCreateImageResponseTopic = "completed-create-image";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing image. */
        public const string WantsUpdateImageRequestTopic = "wants-update-image";
        public const string FinalizedUpdateImageResponseTopic = "finalized-update-image";
        public const string CompletedUpdateImageResponseTopic = "completed-update-image";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all images. */
        public const string WantsGetImagesRequestTopic = "wants-get-images";
        public const string FinalizedGetImagesResponseTopic = "finalized-get-images";
        public const string CompletedGetImagesResponseTopic = "completed-get-images";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete a image. */
        public const string WantsDeleteImageRequestTopic = "wants-delete-image";
        public const string CompletedDeleteImageResponseTopic = "completed-delete-image";
        public const string FinalizedDeleteImageResponseTopic = "finalized-delete-image";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific image by its ID. */
        public const string WantsGetImageRequestTopic = "wants-get-image";
        public const string FinalizedGetImageResponseTopic = "finalized-get-image";
        public const string CompletedGetImageResponseTopic = "completed-get-image";

        public const string WantsDeleteImageByTenant = "wants-delete-image-by-tenant";
        //-------------------------------------------------------------------------------------------
    }

    public static class Comparison
    {
        //-------------------------------------------------------------------------------------------
        public const string ComparisonConsumerGroup = "comparison-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new image. */
        public const string WantsCreateWeeklyComparisonTopic = "wants-create-weekly-comparison";
        public const string FinalizedCreateWeeklyComparisonTopic = "finalized-create-weekly-comparison";
        public const string CompletedCreateWeeklyComparisonTopic = "completed-create-weekly-comparison";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all weekly-comparisons. */
        public const string WantsGetWeeklyComparisonsTopic = "wants-get-weekly-comparisons";
        public const string FinalizedGetWeeklyComparisonsTopic = "finalized-get-weekly-comparisons";
        public const string CompletedGetWeeklyComparisonsTopic = "completed-get-weekly-comparisons";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific weekly-comparison by its ID. */
        public const string WantsGetWeeklyComparisonTopic = "wants-get-weekly-comparison";
        public const string FinalizedGetWeeklyComparisonTopic = "finalized-get-weekly-comparison";
        public const string CompletedGetWeeklyComparisonTopic = "completed-get-weekly-comparison";
        //-------------------------------------------------------------------------------------------
    }

    public static class SubMenuManagement
    {
        public const string SubMenuManagementConsumerGroup = "sub-menu-management-service";
        /* Triggered when a request is made to create a new submenu. */
        public const string WantsCreateSubMenuRequestTopic = "wants-create-submenu";
        public const string FinalizedCreateSubMenuResponseTopic = "finalized-create-submenu";
        public const string CompletedCreateSubMenuResponseTopic = "completed-create-submenu";
        /* Triggered when a request is made to update an existing submenu. */
        public const string WantsUpdateSubMenuRequestTopic = "wants-update-submenu";
        public const string FinalizedUpdateSubMenuResponseTopic = "finalized-update-submenu";
        public const string CompletedUpdateSubMenuResponseTopic = "completed-update-submenu";
        /* Triggered when a request is made to retrieve a list of submenus. */
        public const string WantsGetSubMenusRequestTopic = "wants-get-submenus";
        public const string FinalizedGetSubMenusResponseTopic = "finalized-get-submenus";
        public const string CompletedGetSubMenusResponseTopic = "completed-get-submenus";
        /* Triggered when a request is made to delete an existing submenu. */
        public const string WantsDeleteSubMenuRequestTopic = "wants-delete-submenu";
        public const string FinalizedDeleteSubMenuResponseTopic = "finalized-delete-submenu";
        public const string CompletedDeleteSubMenuResponseTopic = "completed-delete-submenu";
        /* Triggered when a request is made to retrieve a specific submenu. */
        public const string WantsGetSubMenuRequestTopic = "wants-get-submenu";
        public const string FinalizedGetSubMenuResponseTopic = "finalized-get-submenu";
        public const string CompletedGetSubMenuResponseTopic = "completed-get-submenu";
    }


    public static class RoleManagement
    {
        public const string RoleManagementConsumerGroup = "role-management-service";
        /* Triggered when a request is made to create a new role. */
        public const string WantsCreateRoleRequestTopic = "wants-create-role";
        public const string FinalizedCreateRoleResponseTopic = "finalized-create-role";
        public const string CompletedCreateRoleResponseTopic = "completed-create-role";
        /* Triggered when a request is made to update an existing role. */
        public const string WantsUpdateRoleRequestTopic = "wants-update-role";
        public const string FinalizedUpdateRoleResponseTopic = "finalized-update-role";
        public const string CompletedUpdateRoleResponseTopic = "completed-update-role";
        /* Triggered when a request is made to retrieve a list of roles. */
        public const string WantsGetRolesRequestTopic = "wants-get-roles";
        public const string FinalizedGetRolesResponseTopic = "finalized-get-roles";
        public const string CompletedGetRolesResponseTopic = "completed-get-roles";
        /* Triggered when a request is made to delete an existing role. */
        public const string WantsDeleteRoleRequestTopic = "wants-delete-role";
        public const string FinalizedDeleteRoleResponseTopic = "finalized-delete-role";
        public const string CompletedDeleteRoleResponseTopic = "completed-delete-role";
        /* Triggered when a request is made to retrieve a specific role. */
        public const string WantsGetRoleRequestTopic = "wants-get-role";
        public const string FinalizedGetRoleResponseTopic = "finalized-get-role";
        public const string CompletedGetRoleResponseTopic = "completed-get-role";
    }


    public static class MenuManagement
    {
        public const string MenuManagementConsumerGroup = "menu-management-service";
        /* Triggered when a request is made to create a new menu. */
        public const string WantsCreateMenuRequestTopic = "wants-create-menu";
        public const string FinalizedCreateMenuResponseTopic = "finalized-create-menu";
        public const string CompletedCreateMenuResponseTopic = "completed-create-menu";
        /* Triggered when a request is made to update an existing menu. */
        public const string WantsUpdateMenuRequestTopic = "wants-update-menu";
        public const string FinalizedUpdateMenuResponseTopic = "finalized-update-menu";
        public const string CompletedUpdateMenuResponseTopic = "completed-update-menu";
        /* Triggered when a request is made to retrieve a list of menus. */
        public const string WantsGetMenusRequestTopic = "wants-get-menus";
        public const string FinalizedGetMenusResponseTopic = "finalized-get-menus";
        public const string CompletedGetMenusResponseTopic = "completed-get-menus";
        /* Triggered when a request is made to delete an existing menu. */
        public const string WantsDeleteMenuRequestTopic = "wants-delete-menu";
        public const string FinalizedDeleteMenuResponseTopic = "finalized-delete-menu";
        public const string CompletedDeleteMenuResponseTopic = "completed-delete-menu";
        /* Triggered when a request is made to retrieve a specific menu. */
        public const string WantsGetMenuRequestTopic = "wants-get-menu";
        public const string FinalizedGetMenuResponseTopic = "finalized-get-menu";
        public const string CompletedGetMenuResponseTopic = "completed-get-menu";
    }

    public static class APIPermissionManagement
    {
        public const string APIPermissionManagementConsumerGroup = "api-permission-management-service";
        /* Triggered when a request is made to create a new API permission. */
        public const string WantsCreateAPIPermissionRequestTopic = "wants-create-api-permission";
        public const string FinalizedCreateAPIPermissionResponseTopic = "finalized-create-api-permission";
        public const string CompletedCreateAPIPermissionResponseTopic = "completed-create-api-permission";
        /* Triggered when a request is made to update an existing API permission. */
        public const string WantsUpdateAPIPermissionRequestTopic = "wants-update-api-permission";
        public const string FinalizedUpdateAPIPermissionResponseTopic = "finalized-update-api-permission";
        public const string CompletedUpdateAPIPermissionResponseTopic = "completed-update-api-permission";
        /* Triggered when a request is made to retrieve a list of API permissions. */
        public const string WantsGetAPIPermissionsRequestTopic = "wants-get-api-permissions";
        public const string FinalizedGetAPIPermissionsResponseTopic = "finalized-get-api-permissions";
        public const string CompletedGetAPIPermissionsResponseTopic = "completed-get-api-permissions";
        /* Triggered when a request is made to delete an existing API permission. */
        public const string WantsDeleteAPIPermissionRequestTopic = "wants-delete-api-permission";
        public const string FinalizedDeleteAPIPermissionResponseTopic = "finalized-delete-api-permission";
        public const string CompletedDeleteAPIPermissionResponseTopic = "completed-delete-api-permission";
        /* Triggered when a request is made to retrieve a specific API permission. */
        public const string WantsGetAPIPermissionRequestTopic = "wants-get-api-permission";
        public const string FinalizedGetAPIPermissionResponseTopic = "finalized-get-api-permission";
        public const string CompletedGetAPIPermissionResponseTopic = "completed-get-api-permission";
    }

    public static class UserToRoleMapper
    {
        public const string UserToRoleMapperConsumerGroup = "user-to-role-mapper-service";
        /* Triggered when a request is made to create a new UserToRoleMapper. */
        public const string WantsCreateUserToRoleMapperRequestTopic = "wants-create-user-to-role-mapper";
        public const string FinalizedCreateUserToRoleMapperResponseTopic = "finalized-create-user-to-role-mapper";
        public const string CompletedCreateUserToRoleMapperResponseTopic = "completed-create-user-to-role-mapper";
        /* Triggered when a request is made to update an existing UserToRoleMapper. */
        public const string WantsUpdateUserToRoleMapperRequestTopic = "wants-update-user-to-role-mapper";
        public const string FinalizedUpdateUserToRoleMapperResponseTopic = "finalized-update-user-to-role-mapper";
        public const string CompletedUpdateUserToRoleMapperResponseTopic = "completed-update-user-to-role-mapper";
        /* Triggered when a request is made to retrieve a list of UserToRoleMappers. */
        public const string WantsGetUserToRoleMappersRequestTopic = "wants-get-user-to-role-mappers";
        public const string FinalizedGetUserToRoleMappersResponseTopic = "finalized-get-user-to-role-mappers";
        public const string CompletedGetUserToRoleMappersResponseTopic = "completed-get-user-to-role-mappers";
        /* Triggered when a request is made to delete an existing UserToRoleMapper. */
        public const string WantsDeleteUserToRoleMapperRequestTopic = "wants-delete-user-to-role-mapper";
        public const string FinalizedDeleteUserToRoleMapperResponseTopic = "finalized-delete-user-to-role-mapper";
        public const string CompletedDeleteUserToRoleMapperResponseTopic = "completed-delete-user-to-role-mapper";
        /* Triggered when a request is made to retrieve a specific UserToRoleMapper. */
        public const string WantsGetUserToRoleMapperRequestTopic = "wants-get-user-to-role-mapper";
        public const string FinalizedGetUserToRoleMapperResponseTopic = "finalized-get-user-to-role-mapper";
        public const string CompletedGetUserToRoleMapperResponseTopic = "completed-get-user-to-role-mapper";
    }

    public static class AccessShield
    {
        public const string AccessShieldConsumerGroup = "access-shield-service";
        //---------------------------------------------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a specific User access details. */
        public const string WantsGetAccessShieldRequestTopic = "wants-get-access-shield-details";
        public const string FinalizedGetAccessShieldResponseTopic = "finalized-get-access-shield-details";
        public const string CompletedGetAccessShieldResponseTopic = "completed-get-access-shield-details";
        //-------------------------------------------------------------------------------------------------------------------------------
        public const string WantsCreateAccessShieldRequestTopic = "wants-create-access-shield-details";
        public const string FinalizedCreateAccessShieldResponseTopic = "finalized-create-access-shield-details";
        public const string CompletedCreateAccessShieldResponseTopic = "completed-create-access-shield-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Delete Access Shield
        public const string WantsDeleteAccessShieldRequestTopic = "wants-delete-access-shield-details";
        public const string FinalizedDeleteAccessShieldResponseTopic = "finalized-delete-access-shield-details";
        public const string CompletedDeleteAccessShieldResponseTopic = "completed-delete-access-shield-details";
        //-------------------------------------------------------------------------------------------------------------------------------
        // Get All Access Shield Details
        public const string WantsGetAccessShieldsRequestTopic = "wants-get-all-access-shield-details";
        public const string FinalizedGetAccessShieldsResponseTopic = "finalized-get-all-access-shield-details";
        public const string CompletedGetAccessShieldsResponseTopic = "completed-get-all-access-shield-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Update Access Shield
        public const string WantsUpdateAccessShieldRequestTopic = "wants-update-access-shield-details";
        public const string FinalizedUpdateAccessShieldResponseTopic = "finalized-update-access-shield-details";
        public const string CompletedUpdateAccessShieldResponseTopic = "completed-update-access-shield-details";
        //-------------------------------------------------------------------------------------------------------------------------------
    }
    public static class AuthenticationProviders
    {
        public const string AuthenticationProvidersConsumerGroup = "authentication-providers-service";
        //---------------------------------------------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a specific authentication provider's details. */
        public const string WantsGetAuthenticationProviderRequestTopic = "wants-get-authentication-provider-details";
        public const string FinalizedGetAuthenticationProviderResponseTopic = "finalized-get-authentication-provider-details";
        public const string CompletedGetAuthenticationProviderResponseTopic = "completed-get-authentication-provider-details";
        //-------------------------------------------------------------------------------------------------------------------------------
        // Create Authentication Provider
        public const string WantsCreateAuthenticationProviderRequestTopic = "wants-create-authentication-provider-details";
        public const string FinalizedCreateAuthenticationProviderResponseTopic = "finalized-create-authentication-provider-details";
        public const string CompletedCreateAuthenticationProviderResponseTopic = "completed-create-authentication-provider-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Delete Authentication Provider
        public const string WantsDeleteAuthenticationProviderRequestTopic = "wants-delete-authentication-provider-details";
        public const string FinalizedDeleteAuthenticationProviderResponseTopic = "finalized-delete-authentication-provider-details";
        public const string CompletedDeleteAuthenticationProviderResponseTopic = "completed-delete-authentication-provider-details";
        //-------------------------------------------------------------------------------------------------------------------------------
        // Get All Authentication Providers Details
        public const string WantsGetAuthenticationProvidersRequestTopic = "wants-get-all-authentication-providers-details";
        public const string FinalizedGetAuthenticationProvidersResponseTopic = "finalized-get-all-authentication-providers-details";
        public const string CompletedGetAuthenticationProvidersResponseTopic = "completed-get-all-authentication-providers-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Update Authentication Provider
        public const string WantsUpdateAuthenticationProviderRequestTopic = "wants-update-authentication-provider-details";
        public const string FinalizedUpdateAuthenticationProviderResponseTopic = "finalized-update-authentication-provider-details";
        public const string CompletedUpdateAuthenticationProviderResponseTopic = "completed-update-authentication-provider-details";
        //-------------------------------------------------------------------------------------------------------------------------------
    }
    public static class Currency
    {
        public const string CurrencyServiceConsumerGroup = "currency-service";

        //---------------------------------------------------------------------------------------------------------------------------------
        /* Triggered when a request is made to retrieve a specific currency's details. */
        public const string WantsGetCurrencyRequestTopic = "wants-get-currency-details";
        public const string FinalizedGetCurrencyResponseTopic = "finalized-get-currency-details";
        public const string CompletedGetCurrencyResponseTopic = "completed-get-currency-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Create Currency
        public const string WantsCreateCurrencyRequestTopic = "wants-create-currency-details";
        public const string FinalizedCreateCurrencyResponseTopic = "finalized-create-currency-details";
        public const string CompletedCreateCurrencyResponseTopic = "completed-create-currency-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Delete Currency
        public const string WantsDeleteCurrencyRequestTopic = "wants-delete-currency-details";
        public const string FinalizedDeleteCurrencyResponseTopic = "finalized-delete-currency-details";
        public const string CompletedDeleteCurrencyResponseTopic = "completed-delete-currency-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Get All Currencies Details
        public const string WantsGetAllCurrenciesRequestTopic = "wants-get-all-currencies-details";
        public const string FinalizedGetAllCurrenciesResponseTopic = "finalized-get-all-currencies-details";
        public const string CompletedGetAllCurrenciesResponseTopic = "completed-get-all-currencies-details";
        //---------------------------------------------------------------------------------------------------------------------------------
        // Update Currency
        public const string WantsUpdateCurrencyRequestTopic = "wants-update-currency-details";
        public const string FinalizedUpdateCurrencyResponseTopic = "finalized-update-currency-details";
        public const string CompletedUpdateCurrencyResponseTopic = "completed-update-currency-details";
        //---------------------------------------------------------------------------------------------------------------------------------
    }


    public static class ImportCompetitorHotelPrice
    {
        //-------------------------------------------------------------------------------------------
        public const string ImportCompetitorHotelPriceConsumerGroup = "import-competitor-hotel-price-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsUpdateImportCompetitorHotelPriceRequestTopic = "wants-update-import-competitor-hotel-price";
        public const string FinalizedUpdateImportCompetitorHotelPriceResponseTopic = "finalized-update-import-competitor-hotel-price";
        public const string CompletedUpdateImportCompetitorHotelPriceResponseTopic = "completed-update-import-competitor-hotel-price";
        //-------------------------------------------------------------------------------------------
        public const string WantsCreateImportCompetitorHotelPriceRequestTopic = "wants-create-import-competitor-hotel-price";
        public const string FinalizedCreateImportCompetitorHotelPriceResponseTopic = "finalized-create-import-competitor-hotel-price";
        public const string CompletedCreateImportCompetitorHotelPriceResponseTopic = "completed-create-import-competitor-hotel-price";
        //-------------------------------------------------------------------------------------------
        public const string WantsImportCompetitorHotelPriceRequestTopic = "wants-import-competitor-hotel-price";
        public const string FinalizedImportCompetitorHotelPriceResponseTopic = "finalized-import-competitor-hotel-price";
        public const string CompletedImportCompetitorHotelPriceResponseTopic = "completed-import-competitor-hotel-price";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetImportCompetitorHotelPriceRequestTopic = "wants-get-import-competitor-hotel-price";
        public const string CompletedGetImportCompetitorHotelPriceResponseTopic = "completed-get-import-competitor-hotel-price";
        public const string FinalizedGetImportCompetitorHotelPriceResponseTopic = "finalized-get-import-competitor-hotel-price";
    }

    public static class WeeklyComparisionJobs
    {
        //-------------------------------------------------------------------------------------------
        public const string WeeklyComparisonJobsConsumerGroup = "weekly-comparison-jobs-service";
        //-------------------------------------------------------------------------------------------
        // Topics for manualjobs requests
        public const string WantsWeeklyComparisonJobsManualRequestTopic = "wants-weekly-comparison-jobs-manual";
        public const string FinalizedWeeklyComparisonJobsManualResponseTopic = "finalized-weekly-comparison-jobs-manual";
        public const string CompletedWeeklyComparisonJobsManualResponseTopic = "completed-weekly-comparison-jobs-manual";
        //-------------------------------------------------------------------------------------------
        // Topics for clusteringjobs requests
        public const string WantsWeeklyComparisonClusteringRequestTopic = "wants-weekly-comparison-clustering";
        public const string FinalizedWeeklyComparisonClusteringResponseTopic = "finalized-weekly-comparison-clustering";
        public const string CompletedWeeklyComparisonClusteringResponseTopic = "completed-weekly-comparison-clustering";
        //-------------------------------------------------------------------------------------------
        // Topics for automaticjobs requests
        public const string WantsWeeklyComparisonJobsAutomaticRequestTopic = "wants-weekly-comparison-jobs-automatic";
        public const string FinalizedWeeklyComparisonJobsAutomaticResponseTopic = "finalized-weekly-comparison-jobs-automatic";
        public const string CompletedWeeklyComparisonJobsAutomaticResponseTopic = "completed-weekly-comparison-jobs-automatic";
        //------------------------------------------------------------------------------------------------
        // Topics for expressjobs requests
        public const string WantsWeeklyComparisonJobsExpressRequestTopic = "wants-weekly-comparison-jobs-express";
        public const string FinalizedWeeklyComparisonJobsExpressResponseTopic = "finalized-weekly-comparison-jobs-express";
        public const string CompletedWeeklyComparisonJobsExpressResponseTopic = "completed-weekly-comparison-jobs-express";
    }

    public static class CompetitorOffer
    {
        //-------------------------------------------------------------------------------------------
        public const string CompetitorOffersConsumerGroup = "competitor-offers-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new competitorOffer. */
        public const string WantsCreateCompetitorOfferRequestTopic = "wants-create-CompetitorOffer";
        public const string FinalizedCreateCompetitorOfferResponseTopic = "finalized-create-CompetitorOffer";
        public const string CompletedCreateCompetitorOfferResponseTopic = "completed-create-CompetitorOffer";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing competitorOffer. */
        public const string WantsUpdateCompetitorOfferRequestTopic = "wants-update-CompetitorOffer";
        public const string FinalizedUpdateCompetitorOfferResponseTopic = "finalized-update-CompetitorOffer";
        public const string CompletedUpdateCompetitorOfferResponseTopic = "completed-update-CompetitorOffer";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all competitorOffers. */
        public const string WantsGetCompetitorOffersRequestTopic = "wants-get-CompetitorOffers";
        public const string FinalizedGetCompetitorOffersResponseTopic = "finalized-get-CompetitorOffers";
        public const string CompletedGetCompetitorOffersResponseTopic = "completed-get-CompetitorOffers";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete a competitorOffer. */
        public const string WantsDeleteCompetitorOfferRequestTopic = "wants-delete-CompetitorOffer";
        public const string CompletedDeleteCompetitorOfferResponseTopic = "completed-delete-CompetitorOffer";
        public const string FinalizedDeleteCompetitorOfferResponseTopic = "finalized-delete-CompetitorOffer";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific competitorOffer by its ID. */
        public const string WantsGetCompetitorOfferRequestTopic = "wants-get-CompetitorOffer";
        public const string FinalizedGetCompetitorOfferResponseTopic = "finalized-get-CompetitorOffer";
        public const string CompletedGetCompetitorOfferResponseTopic = "completed-get-CompetitorOffer";
        //-------------------------------------------------------------------------------------------
    }

    public static class SocialMediaSetting
    {
        //-------------------------------------------------------------------------------------------
        public const string SocialMediaSettingsConsumerGroup = "social-media-setting-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new socialMediaSetting. */
        public const string WantsUpsertSocialMediaSettingRequestTopic = "wants-upsert-SocialMediaSetting";
        public const string CompletedUpsertSocialMediaSettingResponseTopic = "completed-upsert-SocialMediaSetting";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing socialMediaSetting. */
        public const string WantsUpdateSocialMediaSettingRequestTopic = "wants-update-SocialMediaSetting";
        public const string CompletedUpdateSocialMediaSettingResponseTopic = "completed-update-SocialMediaSetting";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific socialMediaSetting by its ID. */
        public const string WantsGetSocialMediaSettingRequestTopic = "wants-get-SocialMediaSetting";
        public const string CompletedGetSocialMediaSettingResponseTopic = "completed-get-SocialMediaSetting";
        //-------------------------------------------------------------------------------------------
    }

    public static class MarketingBudgetSetting
    {
        // Consumer Group
        public const string MarketingBudgetSettingsConsumerGroup = "marketing-budget-setting-service";

        // Create
        public const string WantsCreateMarketingBudgetSettingRequestTopic = "wants-create-MarketingBudgetSetting";
        public const string CompletedCreateMarketingBudgetSettingResponseTopic = "completed-create-MarketingBudgetSetting";

        // Update
        public const string WantsUpdateMarketingBudgetSettingRequestTopic = "wants-update-MarketingBudgetSetting";
        public const string CompletedUpdateMarketingBudgetSettingResponseTopic = "completed-update-MarketingBudgetSetting";

        // Get by ID
        public const string WantsGetMarketingBudgetSettingRequestTopic = "wants-get-MarketingBudgetSetting";
        public const string CompletedGetMarketingBudgetSettingResponseTopic = "completed-get-MarketingBudgetSetting";

        // Get All
        public const string WantsGetAllMarketingBudgetSettingsRequestTopic = "wants-getAll-MarketingBudgetSettings";
        public const string CompletedGetAllMarketingBudgetSettingsResponseTopic = "completed-getAll-MarketingBudgetSettings";

        // Delete
        public const string WantsDeleteMarketingBudgetSettingRequestTopic = "wants-delete-MarketingBudgetSetting";
        public const string CompletedDeleteMarketingBudgetSettingResponseTopic = "completed-delete-MarketingBudgetSetting";

        // Marketing Budget Adjustment Topics
        public const string WantsProposeMarketingBudgetAdjustmentRequestTopic = "wants-propose-MarketingBudgetAdjustment";
        public const string CompletedProposeMarketingBudgetAdjustmentResponseTopic = "completed-propose-MarketingBudgetAdjustment";
    }

    public static class Market
    {
        //-------------------------------------------------------------------------------------------
        public const string MarketConsumerGroup = "market-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsCreateMarketRequestTopic = "wants-create-market";
        public const string CompletedCreateMarketResponseTopic = "completed-create-market";
        //-------------------------------------------------------------------------------------------
        public const string WantsUpdateMarketRequestTopic = "wants-update-market";
        public const string CompletedUpdateMarketResponseTopic = "completed-update-market";
        //-------------------------------------------------------------------------------------------
        public const string WantsDeleteMarketRequestTopic = "wants-delete-market";
        public const string CompletedDeleteMarketResponseTopic = "completed-delete-market";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetMarketRequestTopic = "wants-get-market";
        public const string CompletedGetMarketResponseTopic = "completed-get-market";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetMarketsRequestTopic = "wants-get-markets";
        public const string CompletedGetMarketsResponseTopic = "completed-get-markets";
        //-------------------------------------------------------------------------------------------
        public const string WantsImportMarketsRequestTopic = "wants-import-markets";
        public const string CompletedImportMarketsResponseTopic = "completed-import-markets";
        //-------------------------------------------------------------------------------------------
    }

    public static class Weather
    {
        //-------------------------------------------------------------------------------------------
        public const string WeathersConsumerGroup = "weather-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new competitorOffer. */
        public const string WantsImportWeatherRequestTopic = "wants-import-Weather";
        public const string CompletedImportWeatherResponseTopic = "completed-import-Weather";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing competitorOffer. */
        public const string WantsUpdateWeatherRequestTopic = "wants-update-Weather";
        public const string CompletedUpdateWeatherResponseTopic = "completed-update-Weather";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all competitorOffers. */
        public const string WantsGetWeathersRequestTopic = "wants-get-Weathers";
        public const string CompletedGetWeathersResponseTopic = "completed-get-Weathers";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete a competitorOffer. */
        public const string WantsDeleteWeatherRequestTopic = "wants-delete-Weather";
        public const string CompletedDeleteWeatherResponseTopic = "completed-delete-Weather";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific competitorOffer by its ID. */
        public const string WantsGetWeatherRequestTopic = "wants-get-Weather";
        public const string CompletedGetWeatherResponseTopic = "completed-get-Weather";
        //-------------------------------------------------------------------------------------------
    }

    public static class PropertyAnomalySetting
    {
        //-------------------------------------------------------------------------------------------
        public const string PropertyAnomalySettingConsumerGroup = "property-anomaly-setting-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new PropertyAnomalySetting. */
        public const string WantsUpsertPropertyAnomalySettingRequestTopic = "wants-upsert-PropertyAnomalySetting";
        public const string CompletedUpsertPropertyAnomalySettingResponseTopic = "completed-upsert-PropertyAnomalySetting";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific PropertyAnomalySetting by its ID. */
        public const string WantsGetPropertyAnomalySettingRequestTopic = "wants-get-PropertyAnomalySetting";
        public const string CompletedGetPropertyAnomalySettingResponseTopic = "completed-get-PropertyAnomalySetting";
        //-------------------------------------------------------------------------------------------

        public const string WantsGetPropertyAnomalySettingByMandantRequestTopic = "wants-get-PropertyAnomalySetting-by-mandant";
        public const string CompletedGetPropertyAnomalySettingByMandantResponseTopic = "completed-get-PropertyAnomalySetting-by-mandant";
    }

    public static class AsaPmsService
    {
        //-------------------------------------------------------------------------------------------
        public const string AsaPmsServiceConsumerGroup = "asa-pms-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to create a new AsaReservations. */
        public const string WantsImportAsaReservationRequestTopic = "wants-import-AsaReservations";
        public const string CompletedImportAsaReservationResponseTopic = "completed-import-AsaReservations";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific AsaReservations. */
        public const string WantsGetAsaReservationsRequestTopic = "wants-get-AsaReservations";
        public const string CompletedGetAsaReservationsResponseTopic = "completed-get-AsaReservations";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific AsaReservations. */
        public const string WantsConvertStoreAsaPmsToGenericPmsTopic = "wants-convert-store-asa-pms-to-generic-pms";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific AsaReservations. */
        public const string WantsConvertStoreFilePmsToGenericPmsTopic = "wants-convert-store-file-pms-to-generic-pms";
        //-------------------------------------------------------------------------------------------
    }

    public static class SocialMediaCaption
    {
        //-------------------------------------------------------------------------------------------
        public const string SocialMediaConsumerGroup = "social-media-caption-service";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to update an existing caption. */
        public const string WantsUpdateCaptionRequestTopic = "wants-update-caption";
        public const string CompletedUpdateCaptionResponseTopic = "completed-update-caption";
        //-------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load the list of all captions. */
        public const string WantsGetCaptionsRequestTopic = "wants-get-captions";
        public const string CompletedGetCaptionsResponseTopic = "completed-get-captions";
        //---------------------------------------------------------------------------------------------
        /* Triggered when a request is made to delete a caption. */
        public const string WantsDeleteCaptionRequestTopic = "wants-delete-caption";
        public const string CompletedDeleteCaptionResponseTopic = "completed-delete-caption";
        //-----------------------------------------------------------------------------------------------
        /* Triggered when a request is made to load a specific caption by its ID. */
        public const string WantsGetCaptionRequestTopic = "wants-get-caption";
        public const string CompletedGetCaptionResponseTopic = "completed-get-caption";

        public const string WantsDeleteCaptionsByTenant = "wants-delete-caption-by-tenant";
        //-------------------------------------------------------------------------------------------
    }

    public static class Newsletter
    {
        //-------------------------------------------------------------------------------------------
        public const string WantsDeleteNewsletterByTenant = "wants-delete-newsletter-by-tenant";
        //-------------------------------------------------------------------------------------------
    }

    public static class ExternalSystem
    {
        //-------------------------------------------------------------------------------------------
        public const string ExternalSystemConsumerGroup = "external-system-service";
        //-------------------------------------------------------------------------------------------

        /* Triggered when a request is made to add a new external system configuration. */
        public const string WantsAddExternalSystemRequestTopic = "wants-add-external-system";
        public const string CompletedAddExternalSystemResponseTopic = "completed-add-external-system";

        //-------------------------------------------------------------------------------------------

        /* Triggered when a request is made to update an existing external system configuration. */
        public const string WantsUpdateExternalSystemRequestTopic = "wants-update-external-system";
        public const string CompletedUpdateExternalSystemResponseTopic = "completed-update-external-system";

        //-------------------------------------------------------------------------------------------

        /* Triggered when a request is made to retrieve all external systems for a hotel. */
        public const string WantsGetExternalSystemsRequestTopic = "wants-get-external-systems";
        public const string CompletedGetExternalSystemsResponseTopic = "completed-get-external-systems";

        //-------------------------------------------------------------------------------------------

        /* Triggered when a request is made to delete an external system configuration. */
        public const string WantsDeleteExternalSystemRequestTopic = "wants-delete-external-system";
        public const string CompletedDeleteExternalSystemResponseTopic = "completed-delete-external-system";

        //-------------------------------------------------------------------------------------------

        /* Triggered when a request is made to retrieve all external systems for all hotels. */
        public const string WantsGetAllExternalSystemsRequestTopic = "wants-get-all-external-systems";
        public const string CompletedGetAllExternalSystemsResponseTopic = "completed-get-all-external-systems";

        //-------------------------------------------------------------------------------------------
    }

    public static class RoomOccupancy
    {
        public const string WantsCreateRoomOccupancySettingRequestTopic = "wants-create-room-occupancy-setting-request";
        public const string CompletedCreateRoomOccupancySettingResponseTopic = "completed-create-room-occupancy-setting-response";

        public const string WantsGetRoomOccupancySettingRequestTopic = "wants-get-room-occupancy-setting-request";
        public const string CompletedGetRoomOccupancySettingResponseTopic = "completed-get-room-occupancy-setting-response";

        public const string WantsUpdateRoomOccupancySettingRequestTopic = "wants-update-room-occupancy-setting-request";
        public const string CompletedUpdateRoomOccupancySettingResponseTopic = "completed-update-room-occupancy-setting-response";

        public const string WantsDeleteRoomOccupancySettingRequestTopic = "wants-delete-room-occupancy-setting-request";
        public const string CompletedDeleteRoomOccupancySettingResponseTopic = "completed-delete-room-occupancy-setting-response";

        // Topics for fetching anomalies (based on your provided events)
        public const string WantsGetRoomOccupancyAnomaliesRequestTopic = "wants-get-room-occupancy-anomalies-request";
        public const string CompletedGetRoomOccupancyAnomaliesResponseTopic = "completed-get-room-occupancy-anomalies-response";

        // Topics for Get Daily Actual Occupancy by Mandant and Date Range
        public const string WantsGetDailyActualOccupancyByMandantAndDateRangeTopic = "wants-get-daily-actual-occupancy-by-mandant-and-date-range";
        public const string CompletedGetDailyActualOccupancyByMandantAndDateRangeTopic = "completed-get-daily-actual-occupancy-by-mandant-and-date-range";
    }

    public static class BookingAnomaly
    {
        //-------------------------------------------------------------------------------------------
        public const string BookingAnomalyConsumerGroup = "booking-anomaly-service";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetBudgetBookingAnomaliesRequestTopic = "wants-get-budget-booking-anomalies";
        public const string CompletedGetBudgetBookingAnomaliesResponseTopic = "completed-get-budget-booking-anomalies";
        //-------------------------------------------------------------------------------------------
        public const string WantsGetOvernightStayAnomaliesRequestTopic = "wants-get-overnight-stay-anomalies";
        public const string CompletedGetOvernightStayAnomaliesRequestTopic = "completed-get-overnight-stay-anomalies";
        //-------------------------------------------------------------------------------------------
    }
}
