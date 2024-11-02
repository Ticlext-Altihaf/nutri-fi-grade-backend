namespace Server.Models;

    using System;
    using System.Collections.Generic;

    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;

    public partial class Ean13Product
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("product")]
        public Product Product { get; set; }

        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("status_verbose")]
        public string StatusVerbose { get; set; }
    }

    public partial class Product
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("_keywords")]
        public string[] Keywords { get; set; }

        [JsonPropertyName("added_countries_tags")]
        public object[] AddedCountriesTags { get; set; }

        [JsonPropertyName("additives_n")]
        public long AdditivesN { get; set; }

        [JsonPropertyName("additives_original_tags")]
        public object[] AdditivesOriginalTags { get; set; }

        [JsonPropertyName("additives_tags")]
        public object[] AdditivesTags { get; set; }

        [JsonPropertyName("allergens")]
        public string Allergens { get; set; }

        [JsonPropertyName("allergens_from_ingredients")]
        public string AllergensFromIngredients { get; set; }

        [JsonPropertyName("allergens_from_user")]
        public string AllergensFromUser { get; set; }

        [JsonPropertyName("allergens_hierarchy")]
        public string[] AllergensHierarchy { get; set; }

        [JsonPropertyName("allergens_tags")]
        public string[] AllergensTags { get; set; }

        [JsonPropertyName("amino_acids_tags")]
        public object[] AminoAcidsTags { get; set; }

        [JsonPropertyName("brands")]
        public string Brands { get; set; }

        [JsonPropertyName("brands_tags")]
        public string[] BrandsTags { get; set; }

        [JsonPropertyName("categories")]
        public string Categories { get; set; }

        [JsonPropertyName("categories_hierarchy")]
        public string[] CategoriesHierarchy { get; set; }

        [JsonPropertyName("categories_lc")]
        public string CategoriesLc { get; set; }

        [JsonPropertyName("categories_properties")]
        public CategoriesProperties CategoriesProperties { get; set; }

        [JsonPropertyName("categories_properties_tags")]
        public string[] CategoriesPropertiesTags { get; set; }

        [JsonPropertyName("categories_tags")]
        public string[] CategoriesTags { get; set; }

        [JsonPropertyName("checkers_tags")]
        public object[] CheckersTags { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("codes_tags")]
        public string[] CodesTags { get; set; }

        [JsonPropertyName("compared_to_category")]
        public string ComparedToCategory { get; set; }

        [JsonPropertyName("complete")]
        public long Complete { get; set; }

        [JsonPropertyName("completeness")]
        public double Completeness { get; set; }

        [JsonPropertyName("correctors_tags")]
        public string[] CorrectorsTags { get; set; }

        [JsonPropertyName("countries")]
        public string Countries { get; set; }

        [JsonPropertyName("countries_hierarchy")]
        public string[] CountriesHierarchy { get; set; }

        [JsonPropertyName("countries_tags")]
        public string[] CountriesTags { get; set; }

        [JsonPropertyName("created_t")]
        public long CreatedT { get; set; }

        [JsonPropertyName("creator")]
        public string Creator { get; set; }

        [JsonPropertyName("data_quality_bugs_tags")]
        public object[] DataQualityBugsTags { get; set; }

        [JsonPropertyName("data_quality_errors_tags")]
        public object[] DataQualityErrorsTags { get; set; }

        [JsonPropertyName("data_quality_info_tags")]
        public string[] DataQualityInfoTags { get; set; }

        [JsonPropertyName("data_quality_tags")]
        public string[] DataQualityTags { get; set; }

        [JsonPropertyName("data_quality_warnings_tags")]
        public string[] DataQualityWarningsTags { get; set; }

        [JsonPropertyName("data_sources")]
        public string DataSources { get; set; }

        [JsonPropertyName("data_sources_tags")]
        public string[] DataSourcesTags { get; set; }

        [JsonPropertyName("ecoscore_data")]
        public EcoscoreData EcoscoreData { get; set; }

        [JsonPropertyName("ecoscore_grade")]
        public EcoscoreGrade EcoscoreGrade { get; set; }

        [JsonPropertyName("ecoscore_score")]
        public long EcoscoreScore { get; set; }

        [JsonPropertyName("ecoscore_tags")]
        public EcoscoreGrade[] EcoscoreTags { get; set; }

        [JsonPropertyName("editors_tags")]
        public string[] EditorsTags { get; set; }

        [JsonPropertyName("entry_dates_tags")]
        public string[] EntryDatesTags { get; set; }

        [JsonPropertyName("food_groups_tags")]
        public object[] FoodGroupsTags { get; set; }

        [JsonPropertyName("id")]
        public string ProductId { get; set; }

        [JsonPropertyName("image_front_small_url")]
        public Uri ImageFrontSmallUrl { get; set; }

        [JsonPropertyName("image_front_thumb_url")]
        public Uri ImageFrontThumbUrl { get; set; }

        [JsonPropertyName("image_front_url")]
        public Uri ImageFrontUrl { get; set; }

        [JsonPropertyName("image_ingredients_small_url")]
        public Uri ImageIngredientsSmallUrl { get; set; }

        [JsonPropertyName("image_ingredients_thumb_url")]
        public Uri ImageIngredientsThumbUrl { get; set; }

        [JsonPropertyName("image_ingredients_url")]
        public Uri ImageIngredientsUrl { get; set; }

        [JsonPropertyName("image_nutrition_small_url")]
        public Uri ImageNutritionSmallUrl { get; set; }

        [JsonPropertyName("image_nutrition_thumb_url")]
        public Uri ImageNutritionThumbUrl { get; set; }

        [JsonPropertyName("image_nutrition_url")]
        public Uri ImageNutritionUrl { get; set; }

        [JsonPropertyName("image_packaging_small_url")]
        public Uri ImagePackagingSmallUrl { get; set; }

        [JsonPropertyName("image_packaging_thumb_url")]
        public Uri ImagePackagingThumbUrl { get; set; }

        [JsonPropertyName("image_packaging_url")]
        public Uri ImagePackagingUrl { get; set; }

        [JsonPropertyName("image_small_url")]
        public Uri ImageSmallUrl { get; set; }

        [JsonPropertyName("image_thumb_url")]
        public Uri ImageThumbUrl { get; set; }

        [JsonPropertyName("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonPropertyName("images")]
        public Images Images { get; set; }

        [JsonPropertyName("informers_tags")]
        public string[] InformersTags { get; set; }

        [JsonPropertyName("ingredients")]
        public Ingredient[] Ingredients { get; set; }

        [JsonPropertyName("ingredients_analysis")]
        public IngredientsAnalysis IngredientsAnalysis { get; set; }

        [JsonPropertyName("ingredients_analysis_tags")]
        public string[] IngredientsAnalysisTags { get; set; }

        [JsonPropertyName("ingredients_hierarchy")]
        public string[] IngredientsHierarchy { get; set; }

        [JsonPropertyName("ingredients_lc")]
        public string IngredientsLc { get; set; }

        [JsonPropertyName("ingredients_n")]
        public long IngredientsN { get; set; }

        [JsonPropertyName("ingredients_n_tags")]
        public string[] IngredientsNTags { get; set; }

        [JsonPropertyName("ingredients_non_nutritive_sweeteners_n")]
        public long IngredientsNonNutritiveSweetenersN { get; set; }

        [JsonPropertyName("ingredients_original_tags")]
        public string[] IngredientsOriginalTags { get; set; }

        [JsonPropertyName("ingredients_percent_analysis")]
        public long IngredientsPercentAnalysis { get; set; }

        [JsonPropertyName("ingredients_sweeteners_n")]
        public long IngredientsSweetenersN { get; set; }

        [JsonPropertyName("ingredients_tags")]
        public string[] IngredientsTags { get; set; }

        [JsonPropertyName("ingredients_text")]
        public string IngredientsText { get; set; }

        [JsonPropertyName("ingredients_text_en")]
        public string IngredientsTextEn { get; set; }

        [JsonPropertyName("ingredients_text_with_allergens")]
        public string IngredientsTextWithAllergens { get; set; }

        [JsonPropertyName("ingredients_text_with_allergens_en")]
        public string IngredientsTextWithAllergensEn { get; set; }

        [JsonPropertyName("ingredients_with_specified_percent_n")]
        public long IngredientsWithSpecifiedPercentN { get; set; }

        [JsonPropertyName("ingredients_with_specified_percent_sum")]
        public long IngredientsWithSpecifiedPercentSum { get; set; }

        [JsonPropertyName("ingredients_with_unspecified_percent_n")]
        public long IngredientsWithUnspecifiedPercentN { get; set; }

        [JsonPropertyName("ingredients_with_unspecified_percent_sum")]
        public long IngredientsWithUnspecifiedPercentSum { get; set; }

        [JsonPropertyName("ingredients_without_ciqual_codes")]
        public string[] IngredientsWithoutCiqualCodes { get; set; }

        [JsonPropertyName("ingredients_without_ciqual_codes_n")]
        public long IngredientsWithoutCiqualCodesN { get; set; }

        [JsonPropertyName("ingredients_without_ecobalyse_ids")]
        public string[] IngredientsWithoutEcobalyseIds { get; set; }

        [JsonPropertyName("ingredients_without_ecobalyse_ids_n")]
        public long IngredientsWithoutEcobalyseIdsN { get; set; }

        [JsonPropertyName("interface_version_created")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long InterfaceVersionCreated { get; set; }

        [JsonPropertyName("interface_version_modified")]
        public string InterfaceVersionModified { get; set; }

        [JsonPropertyName("known_ingredients_n")]
        public long KnownIngredientsN { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("languages")]
        public Languages Languages { get; set; }

        [JsonPropertyName("languages_codes")]
        public LanguagesCodes LanguagesCodes { get; set; }

        [JsonPropertyName("languages_hierarchy")]
        public string[] LanguagesHierarchy { get; set; }

        [JsonPropertyName("languages_tags")]
        public string[] LanguagesTags { get; set; }

        [JsonPropertyName("last_edit_dates_tags")]
        public string[] LastEditDatesTags { get; set; }

        [JsonPropertyName("last_editor")]
        public string LastEditor { get; set; }

        [JsonPropertyName("last_image_dates_tags")]
        public string[] LastImageDatesTags { get; set; }

        [JsonPropertyName("last_image_t")]
        public long LastImageT { get; set; }

        [JsonPropertyName("last_modified_by")]
        public string LastModifiedBy { get; set; }

        [JsonPropertyName("last_modified_t")]
        public long LastModifiedT { get; set; }

        [JsonPropertyName("last_updated_t")]
        public long LastUpdatedT { get; set; }

        [JsonPropertyName("lc")]
        public string Lc { get; set; }

        [JsonPropertyName("main_countries_tags")]
        public object[] MainCountriesTags { get; set; }

        [JsonPropertyName("max_imgid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MaxImgid { get; set; }

        [JsonPropertyName("minerals_tags")]
        public object[] MineralsTags { get; set; }

        [JsonPropertyName("misc_tags")]
        public string[] MiscTags { get; set; }

        [JsonPropertyName("no_nutrition_data")]
        public string NoNutritionData { get; set; }

        [JsonPropertyName("nova_group")]
        public long NovaGroup { get; set; }

        [JsonPropertyName("nova_group_debug")]
        public string NovaGroupDebug { get; set; }

        [JsonPropertyName("nova_groups")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NovaGroups { get; set; }

        [JsonPropertyName("nova_groups_markers")]
        public Dictionary<string, string[][]> NovaGroupsMarkers { get; set; }

        [JsonPropertyName("nova_groups_tags")]
        public string[] NovaGroupsTags { get; set; }

        [JsonPropertyName("nucleotides_tags")]
        public object[] NucleotidesTags { get; set; }

        [JsonPropertyName("nutrient_levels")]
        public NutrientLevels NutrientLevels { get; set; }

        [JsonPropertyName("nutrient_levels_tags")]
        public string[] NutrientLevelsTags { get; set; }

        [JsonPropertyName("nutriments")]
        public Nutriments Nutriments { get; set; }

        [JsonPropertyName("nutriscore")]
        public Dictionary<string, Nutriscore> Nutriscore { get; set; }

        [JsonPropertyName("nutriscore_2021_tags")]
        public string[] Nutriscore2021_Tags { get; set; }

        [JsonPropertyName("nutriscore_2023_tags")]
        public string[] Nutriscore2023_Tags { get; set; }

        [JsonPropertyName("nutriscore_grade")]
        public string NutriscoreGrade { get; set; }

        [JsonPropertyName("nutriscore_tags")]
        public string[] NutriscoreTags { get; set; }

        [JsonPropertyName("nutriscore_version")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NutriscoreVersion { get; set; }

        [JsonPropertyName("nutrition_data")]
        public string NutritionData { get; set; }

        [JsonPropertyName("nutrition_data_per")]
        public string NutritionDataPer { get; set; }

        [JsonPropertyName("nutrition_data_prepared_per")]
        public string NutritionDataPreparedPer { get; set; }

        [JsonPropertyName("nutrition_grade_fr")]
        public string NutritionGradeFr { get; set; }

        [JsonPropertyName("nutrition_grades")]
        public string NutritionGrades { get; set; }

        [JsonPropertyName("nutrition_grades_tags")]
        public string[] NutritionGradesTags { get; set; }

        [JsonPropertyName("nutrition_score_beverage")]
        public long NutritionScoreBeverage { get; set; }

        [JsonPropertyName("nutrition_score_debug")]
        public string NutritionScoreDebug { get; set; }

        [JsonPropertyName("nutrition_score_warning_no_fiber")]
        public long NutritionScoreWarningNoFiber { get; set; }

        [JsonPropertyName("nutrition_score_warning_no_fruits_vegetables_nuts")]
        public long NutritionScoreWarningNoFruitsVegetablesNuts { get; set; }

        [JsonPropertyName("other_nutritional_substances_tags")]
        public object[] OtherNutritionalSubstancesTags { get; set; }

        [JsonPropertyName("packaging_materials_tags")]
        public object[] PackagingMaterialsTags { get; set; }

        [JsonPropertyName("packaging_recycling_tags")]
        public object[] PackagingRecyclingTags { get; set; }

        [JsonPropertyName("packaging_shapes_tags")]
        public object[] PackagingShapesTags { get; set; }

        [JsonPropertyName("packagings")]
        public object[] Packagings { get; set; }

        [JsonPropertyName("packagings_materials")]
        public PackagingsMaterials PackagingsMaterials { get; set; }

        [JsonPropertyName("photographers_tags")]
        public string[] PhotographersTags { get; set; }

        [JsonPropertyName("pnns_groups_1")]
        public string PnnsGroups1 { get; set; }

        [JsonPropertyName("pnns_groups_1_tags")]
        public string[] PnnsGroups1_Tags { get; set; }

        [JsonPropertyName("pnns_groups_2")]
        public string PnnsGroups2 { get; set; }

        [JsonPropertyName("pnns_groups_2_tags")]
        public string[] PnnsGroups2_Tags { get; set; }

        [JsonPropertyName("popularity_key")]
        public long PopularityKey { get; set; }

        [JsonPropertyName("popularity_tags")]
        public string[] PopularityTags { get; set; }

        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        [JsonPropertyName("product_name_en")]
        public string ProductNameEn { get; set; }

        [JsonPropertyName("product_quantity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ProductQuantity { get; set; }

        [JsonPropertyName("product_quantity_unit")]
        public string ProductQuantityUnit { get; set; }

        [JsonPropertyName("product_type")]
        public string ProductType { get; set; }

        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        [JsonPropertyName("removed_countries_tags")]
        public object[] RemovedCountriesTags { get; set; }

        [JsonPropertyName("rev")]
        public long Rev { get; set; }

        [JsonPropertyName("scans_n")]
        public long ScansN { get; set; }

        [JsonPropertyName("selected_images")]
        public SelectedImages SelectedImages { get; set; }

        [JsonPropertyName("serving_quantity")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ServingQuantity { get; set; }

        [JsonPropertyName("serving_quantity_unit")]
        public string ServingQuantityUnit { get; set; }

        [JsonPropertyName("serving_size")]
        public string ServingSize { get; set; }

        [JsonPropertyName("states")]
        public string States { get; set; }

        [JsonPropertyName("states_hierarchy")]
        public string[] StatesHierarchy { get; set; }

        [JsonPropertyName("states_tags")]
        public string[] StatesTags { get; set; }

        [JsonPropertyName("traces")]
        public string Traces { get; set; }

        [JsonPropertyName("traces_from_ingredients")]
        public string TracesFromIngredients { get; set; }

        [JsonPropertyName("traces_from_user")]
        public string TracesFromUser { get; set; }

        [JsonPropertyName("traces_hierarchy")]
        public object[] TracesHierarchy { get; set; }

        [JsonPropertyName("traces_tags")]
        public object[] TracesTags { get; set; }

        [JsonPropertyName("unique_scans_n")]
        public long UniqueScansN { get; set; }

        [JsonPropertyName("unknown_ingredients_n")]
        public long UnknownIngredientsN { get; set; }

        [JsonPropertyName("unknown_nutrients_tags")]
        public object[] UnknownNutrientsTags { get; set; }

        [JsonPropertyName("update_key")]
        public string UpdateKey { get; set; }

        [JsonPropertyName("vitamins_tags")]
        public object[] VitaminsTags { get; set; }

        [JsonPropertyName("weighers_tags")]
        public object[] WeighersTags { get; set; }
    }

    public partial class CategoriesProperties
    {
        [JsonPropertyName("agribalyse_food_code:en")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AgribalyseFoodCodeEn { get; set; }

        [JsonPropertyName("agribalyse_proxy_food_code:en")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AgribalyseProxyFoodCodeEn { get; set; }
    }

    public partial class EcoscoreData
    {
        [JsonPropertyName("adjustments")]
        public Adjustments Adjustments { get; set; }

        [JsonPropertyName("agribalyse")]
        public EcoscoreDataAgribalyse Agribalyse { get; set; }

        [JsonPropertyName("grade")]
        public EcoscoreGrade Grade { get; set; }

        [JsonPropertyName("grades")]
        public Dictionary<string, EcoscoreGrade> Grades { get; set; }

        [JsonPropertyName("missing")]
        public Missing Missing { get; set; }

        [JsonPropertyName("missing_data_warning")]
        public long MissingDataWarning { get; set; }

        [JsonPropertyName("missing_key_data")]
        public long MissingKeyData { get; set; }

        [JsonPropertyName("previous_data")]
        public PreviousData PreviousData { get; set; }

        [JsonPropertyName("score")]
        public long Score { get; set; }

        [JsonPropertyName("scores")]
        public Dictionary<string, long> Scores { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public partial class Adjustments
    {
        [JsonPropertyName("origins_of_ingredients")]
        public OriginsOfIngredients OriginsOfIngredients { get; set; }

        [JsonPropertyName("packaging")]
        public Packaging Packaging { get; set; }

        [JsonPropertyName("production_system")]
        public ProductionSystem ProductionSystem { get; set; }

        [JsonPropertyName("threatened_species")]
        public PackagingsMaterials ThreatenedSpecies { get; set; }
    }

    public partial class OriginsOfIngredients
    {
        [JsonPropertyName("aggregated_origins")]
        public AggregatedOrigin[] AggregatedOrigins { get; set; }

        [JsonPropertyName("epi_score")]
        public long EpiScore { get; set; }

        [JsonPropertyName("epi_value")]
        public long EpiValue { get; set; }

        [JsonPropertyName("origins_from_categories")]
        public string[] OriginsFromCategories { get; set; }

        [JsonPropertyName("origins_from_origins_field")]
        public string[] OriginsFromOriginsField { get; set; }

        [JsonPropertyName("transportation_score")]
        public long TransportationScore { get; set; }

        [JsonPropertyName("transportation_scores")]
        public Dictionary<string, long> TransportationScores { get; set; }

        [JsonPropertyName("transportation_value")]
        public long TransportationValue { get; set; }

        [JsonPropertyName("transportation_values")]
        public Dictionary<string, long> TransportationValues { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("values")]
        public Dictionary<string, long> Values { get; set; }

        [JsonPropertyName("warning")]
        public string Warning { get; set; }
    }

    public partial class AggregatedOrigin
    {
        [JsonPropertyName("epi_score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long EpiScore { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("percent")]
        public long Percent { get; set; }

        [JsonPropertyName("transportation_score")]
        public long TransportationScore { get; set; }
    }

    public partial class Packaging
    {
        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("warning")]
        public string Warning { get; set; }
    }

    public partial class ProductionSystem
    {
        [JsonPropertyName("labels")]
        public object[] Labels { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("warning")]
        public string Warning { get; set; }
    }

    public partial class PackagingsMaterials
    {
    }

    public partial class EcoscoreDataAgribalyse
    {
        [JsonPropertyName("agribalyse_food_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AgribalyseFoodCode { get; set; }

        [JsonPropertyName("co2_agriculture")]
        public double Co2Agriculture { get; set; }

        [JsonPropertyName("co2_consumption")]
        public double Co2Consumption { get; set; }

        [JsonPropertyName("co2_distribution")]
        public double Co2Distribution { get; set; }

        [JsonPropertyName("co2_packaging")]
        public double Co2Packaging { get; set; }

        [JsonPropertyName("co2_processing")]
        public double Co2Processing { get; set; }

        [JsonPropertyName("co2_total")]
        public double Co2Total { get; set; }

        [JsonPropertyName("co2_transportation")]
        public double Co2Transportation { get; set; }

        [JsonPropertyName("code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Code { get; set; }

        [JsonPropertyName("dqr")]
        public string Dqr { get; set; }

        [JsonPropertyName("ef_agriculture")]
        public double EfAgriculture { get; set; }

        [JsonPropertyName("ef_consumption")]
        public double EfConsumption { get; set; }

        [JsonPropertyName("ef_distribution")]
        public double EfDistribution { get; set; }

        [JsonPropertyName("ef_packaging")]
        public double EfPackaging { get; set; }

        [JsonPropertyName("ef_processing")]
        public double EfProcessing { get; set; }

        [JsonPropertyName("ef_total")]
        public double EfTotal { get; set; }

        [JsonPropertyName("ef_transportation")]
        public double EfTransportation { get; set; }

        [JsonPropertyName("is_beverage")]
        public long IsBeverage { get; set; }

        [JsonPropertyName("name_en")]
        public string NameEn { get; set; }

        [JsonPropertyName("name_fr")]
        public string NameFr { get; set; }

        [JsonPropertyName("score")]
        public long Score { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public partial class Missing
    {
        [JsonPropertyName("labels")]
        public long Labels { get; set; }

        [JsonPropertyName("origins")]
        public long Origins { get; set; }

        [JsonPropertyName("packagings")]
        public long Packagings { get; set; }
    }

    public partial class PreviousData
    {
        [JsonPropertyName("agribalyse")]
        public PreviousDataAgribalyse Agribalyse { get; set; }

        [JsonPropertyName("grade")]
        public object Grade { get; set; }

        [JsonPropertyName("score")]
        public object Score { get; set; }
    }

    public partial class PreviousDataAgribalyse
    {
        [JsonPropertyName("warning")]
        public string Warning { get; set; }
    }

    public partial class Images
    {
        [JsonPropertyName("1")]
        public The1 The1 { get; set; }

        [JsonPropertyName("2")]
        public The1 The2 { get; set; }

        [JsonPropertyName("3")]
        public The1 The3 { get; set; }

        [JsonPropertyName("4")]
        public The1 The4 { get; set; }

        [JsonPropertyName("5")]
        public The1 The5 { get; set; }

        [JsonPropertyName("6")]
        public The1 The6 { get; set; }

        [JsonPropertyName("7")]
        public The1 The7 { get; set; }

        [JsonPropertyName("front_en")]
        public FrontEn FrontEn { get; set; }

        [JsonPropertyName("ingredients_en")]
        public IngredientsEn IngredientsEn { get; set; }

        [JsonPropertyName("nutrition_en")]
        public FrontEn NutritionEn { get; set; }

        [JsonPropertyName("nutrition_id")]
        public FrontEn NutritionId { get; set; }

        [JsonPropertyName("packaging_en")]
        public FrontEn PackagingEn { get; set; }
    }

    public partial class FrontEn
    {
        [JsonPropertyName("angle")]
        public long Angle { get; set; }

        [JsonPropertyName("coordinates_image_size")]
        public string CoordinatesImageSize { get; set; }

        [JsonPropertyName("geometry")]
        public string Geometry { get; set; }

        [JsonPropertyName("imgid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Imgid { get; set; }

        [JsonPropertyName("normalize")]
        public object Normalize { get; set; }

        [JsonPropertyName("rev")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rev { get; set; }

        [JsonPropertyName("sizes")]
        public Sizes Sizes { get; set; }

        [JsonPropertyName("white_magic")]
        public object WhiteMagic { get; set; }

        [JsonPropertyName("x1")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long X1 { get; set; }

        [JsonPropertyName("x2")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long X2 { get; set; }

        [JsonPropertyName("y1")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Y1 { get; set; }

        [JsonPropertyName("y2")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Y2 { get; set; }
    }

    public partial class Sizes
    {
        [JsonPropertyName("100")]
        public The100 The100 { get; set; }

        [JsonPropertyName("400")]
        public The100 The400 { get; set; }

        [JsonPropertyName("full")]
        public The100 Full { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("200")]
        public The100 The200 { get; set; }
    }

    public partial class The100
    {
        [JsonPropertyName("h")]
        public long H { get; set; }

        [JsonPropertyName("w")]
        public long W { get; set; }
    }

    public partial class IngredientsEn
    {
        [JsonPropertyName("angle")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Angle { get; set; }

        [JsonPropertyName("coordinates_image_size")]
        public string CoordinatesImageSize { get; set; }

        [JsonPropertyName("geometry")]
        public string Geometry { get; set; }

        [JsonPropertyName("imgid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Imgid { get; set; }

        [JsonPropertyName("normalize")]
        public object Normalize { get; set; }

        [JsonPropertyName("rev")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rev { get; set; }

        [JsonPropertyName("sizes")]
        public Sizes Sizes { get; set; }

        [JsonPropertyName("white_magic")]
        public object WhiteMagic { get; set; }

        [JsonPropertyName("x1")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long X1 { get; set; }

        [JsonPropertyName("x2")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long X2 { get; set; }

        [JsonPropertyName("y1")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Y1 { get; set; }

        [JsonPropertyName("y2")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Y2 { get; set; }
    }

    public partial class The1
    {
        [JsonPropertyName("sizes")]
        public Sizes Sizes { get; set; }

        [JsonPropertyName("uploaded_t")]
        public long UploadedT { get; set; }

        [JsonPropertyName("uploader")]
        public string Uploader { get; set; }
    }

    public partial class Ingredient
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("ciqual_proxy_food_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? CiqualProxyFoodCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("ecobalyse_code")]
        public string EcobalyseCode { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("is_in_taxonomy")]
        public long IsInTaxonomy { get; set; }

        [JsonPropertyName("percent_estimate")]
        public double PercentEstimate { get; set; }

        [JsonPropertyName("percent_max")]
        public double PercentMax { get; set; }

        [JsonPropertyName("percent_min")]
        public long PercentMin { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("rank")]
        public long? Rank { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("vegan")]
        public string Vegan { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("vegetarian")]
        public string Vegetarian { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("ciqual_food_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? CiqualFoodCode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("percent")]
        public long? Percent { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("has_sub_ingredients")]
        public string HasSubIngredients { get; set; }
    }

    public partial class IngredientsAnalysis
    {
        [JsonPropertyName("en:non-vegan")]
        public string[] EnNonVegan { get; set; }

        [JsonPropertyName("en:palm-oil-content-unknown")]
        public string[] EnPalmOilContentUnknown { get; set; }

        [JsonPropertyName("en:vegan-status-unknown")]
        public string[] EnVeganStatusUnknown { get; set; }

        [JsonPropertyName("en:vegetarian-status-unknown")]
        public string[] EnVegetarianStatusUnknown { get; set; }
    }

    public partial class Languages
    {
        [JsonPropertyName("en:english")]
        public long EnEnglish { get; set; }

        [JsonPropertyName("en:indonesian")]
        public long EnIndonesian { get; set; }
    }

    public partial class LanguagesCodes
    {
        [JsonPropertyName("en")]
        public long En { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }
    }

    public partial class NutrientLevels
    {
        [JsonPropertyName("fat")]
        public string Fat { get; set; }

        [JsonPropertyName("salt")]
        public string Salt { get; set; }

        [JsonPropertyName("saturated-fat")]
        public string SaturatedFat { get; set; }

        [JsonPropertyName("sugars")]
        public string Sugars { get; set; }
    }

    public partial class Nutriments
    {
        [JsonPropertyName("alcohol")]
        public long Alcohol { get; set; }

        [JsonPropertyName("alcohol_100g")]
        public long Alcohol100G { get; set; }

        [JsonPropertyName("alcohol_serving")]
        public long AlcoholServing { get; set; }

        [JsonPropertyName("alcohol_unit")]
        public string AlcoholUnit { get; set; }

        [JsonPropertyName("alcohol_value")]
        public long AlcoholValue { get; set; }

        [JsonPropertyName("carbohydrates")]
        public long Carbohydrates { get; set; }

        [JsonPropertyName("carbohydrates_100g")]
        public long Carbohydrates100G { get; set; }

        [JsonPropertyName("carbohydrates_serving")]
        public long CarbohydratesServing { get; set; }

        [JsonPropertyName("carbohydrates_unit")]
        public string CarbohydratesUnit { get; set; }

        [JsonPropertyName("carbohydrates_value")]
        public long CarbohydratesValue { get; set; }

        [JsonPropertyName("energy")]
        public long Energy { get; set; }

        [JsonPropertyName("energy-kcal")]
        public long EnergyKcal { get; set; }

        [JsonPropertyName("energy-kcal_100g")]
        public long EnergyKcal100G { get; set; }

        [JsonPropertyName("energy-kcal_serving")]
        public long EnergyKcalServing { get; set; }

        [JsonPropertyName("energy-kcal_unit")]
        public string EnergyKcalUnit { get; set; }

        [JsonPropertyName("energy-kcal_value")]
        public long EnergyKcalValue { get; set; }

        [JsonPropertyName("energy-kcal_value_computed")]
        public long EnergyKcalValueComputed { get; set; }

        [JsonPropertyName("energy-kj")]
        public long EnergyKj { get; set; }

        [JsonPropertyName("energy-kj_100g")]
        public long EnergyKj100G { get; set; }

        [JsonPropertyName("energy-kj_serving")]
        public long EnergyKjServing { get; set; }

        [JsonPropertyName("energy-kj_unit")]
        public string EnergyKjUnit { get; set; }

        [JsonPropertyName("energy-kj_value")]
        public long EnergyKjValue { get; set; }

        [JsonPropertyName("energy-kj_value_computed")]
        public long EnergyKjValueComputed { get; set; }

        [JsonPropertyName("energy_100g")]
        public long Energy100G { get; set; }

        [JsonPropertyName("energy_serving")]
        public long EnergyServing { get; set; }

        [JsonPropertyName("energy_unit")]
        public string EnergyUnit { get; set; }

        [JsonPropertyName("energy_value")]
        public long EnergyValue { get; set; }

        [JsonPropertyName("fat")]
        public long Fat { get; set; }

        [JsonPropertyName("fat_100g")]
        public long Fat100G { get; set; }

        [JsonPropertyName("fat_serving")]
        public long FatServing { get; set; }

        [JsonPropertyName("fat_unit")]
        public string FatUnit { get; set; }

        [JsonPropertyName("fat_value")]
        public long FatValue { get; set; }

        [JsonPropertyName("fiber")]
        public long Fiber { get; set; }

        [JsonPropertyName("fiber_100g")]
        public long Fiber100G { get; set; }

        [JsonPropertyName("fiber_serving")]
        public long FiberServing { get; set; }

        [JsonPropertyName("fiber_unit")]
        public string FiberUnit { get; set; }

        [JsonPropertyName("fiber_value")]
        public long FiberValue { get; set; }

        [JsonPropertyName("fruits-vegetables-legumes-estimate-from-ingredients_100g")]
        public long FruitsVegetablesLegumesEstimateFromIngredients100G { get; set; }

        [JsonPropertyName("fruits-vegetables-legumes-estimate-from-ingredients_serving")]
        public long FruitsVegetablesLegumesEstimateFromIngredientsServing { get; set; }

        [JsonPropertyName("fruits-vegetables-nuts-estimate-from-ingredients_100g")]
        public long FruitsVegetablesNutsEstimateFromIngredients100G { get; set; }

        [JsonPropertyName("fruits-vegetables-nuts-estimate-from-ingredients_serving")]
        public long FruitsVegetablesNutsEstimateFromIngredientsServing { get; set; }

        [JsonPropertyName("nova-group")]
        public long NovaGroup { get; set; }

        [JsonPropertyName("nova-group_100g")]
        public long NovaGroup100G { get; set; }

        [JsonPropertyName("nova-group_serving")]
        public long NovaGroupServing { get; set; }

        [JsonPropertyName("proteins")]
        public long Proteins { get; set; }

        [JsonPropertyName("proteins_100g")]
        public long Proteins100G { get; set; }

        [JsonPropertyName("proteins_serving")]
        public long ProteinsServing { get; set; }

        [JsonPropertyName("proteins_unit")]
        public string ProteinsUnit { get; set; }

        [JsonPropertyName("proteins_value")]
        public long ProteinsValue { get; set; }

        [JsonPropertyName("salt")]
        public double Salt { get; set; }

        [JsonPropertyName("salt_100g")]
        public double Salt100G { get; set; }

        [JsonPropertyName("salt_serving")]
        public double SaltServing { get; set; }

        [JsonPropertyName("salt_unit")]
        public string SaltUnit { get; set; }

        [JsonPropertyName("salt_value")]
        public double SaltValue { get; set; }

        [JsonPropertyName("saturated-fat")]
        public long SaturatedFat { get; set; }

        [JsonPropertyName("saturated-fat_100g")]
        public long SaturatedFat100G { get; set; }

        [JsonPropertyName("saturated-fat_serving")]
        public long SaturatedFatServing { get; set; }

        [JsonPropertyName("saturated-fat_unit")]
        public string SaturatedFatUnit { get; set; }

        [JsonPropertyName("saturated-fat_value")]
        public long SaturatedFatValue { get; set; }

        [JsonPropertyName("sodium")]
        public double Sodium { get; set; }

        [JsonPropertyName("sodium_100g")]
        public double Sodium100G { get; set; }

        [JsonPropertyName("sodium_serving")]
        public double SodiumServing { get; set; }

        [JsonPropertyName("sodium_unit")]
        public string SodiumUnit { get; set; }

        [JsonPropertyName("sodium_value")]
        public double SodiumValue { get; set; }

        [JsonPropertyName("sugars")]
        public long Sugars { get; set; }

        [JsonPropertyName("sugars_100g")]
        public long Sugars100G { get; set; }

        [JsonPropertyName("sugars_serving")]
        public long SugarsServing { get; set; }

        [JsonPropertyName("sugars_unit")]
        public string SugarsUnit { get; set; }

        [JsonPropertyName("sugars_value")]
        public long SugarsValue { get; set; }
    }

    public partial class Nutriscore
    {
        [JsonPropertyName("category_available")]
        public long CategoryAvailable { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, long?> Data { get; set; }

        [JsonPropertyName("grade")]
        public string Grade { get; set; }

        [JsonPropertyName("nutrients_available")]
        public long NutrientsAvailable { get; set; }

        [JsonPropertyName("nutriscore_applicable")]
        public long NutriscoreApplicable { get; set; }

        [JsonPropertyName("nutriscore_computed")]
        public long NutriscoreComputed { get; set; }
    }

    public partial class SelectedImages
    {
        [JsonPropertyName("front")]
        public Front Front { get; set; }

        [JsonPropertyName("ingredients")]
        public Front Ingredients { get; set; }

        [JsonPropertyName("nutrition")]
        public Nutrition Nutrition { get; set; }

        [JsonPropertyName("packaging")]
        public Front Packaging { get; set; }
    }

    public partial class Front
    {
        [JsonPropertyName("display")]
        public FrontDisplay Display { get; set; }

        [JsonPropertyName("small")]
        public FrontDisplay Small { get; set; }

        [JsonPropertyName("thumb")]
        public FrontDisplay Thumb { get; set; }
    }

    public partial class FrontDisplay
    {
        [JsonPropertyName("en")]
        public Uri En { get; set; }
    }

    public partial class Nutrition
    {
        [JsonPropertyName("display")]
        public NutritionDisplay Display { get; set; }

        [JsonPropertyName("small")]
        public NutritionDisplay Small { get; set; }

        [JsonPropertyName("thumb")]
        public NutritionDisplay Thumb { get; set; }
    }

    public partial class NutritionDisplay
    {
        [JsonPropertyName("en")]
        public Uri En { get; set; }

        [JsonPropertyName("id")]
        public Uri Id { get; set; }
    }

    public enum EcoscoreGrade { A };

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
            {
                EcoscoreGradeConverter.Singleton,
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            },
        };
    }

    internal class ParseStringConverter : JsonConverter<long>
    {
        public override bool CanConvert(Type t) => t == typeof(long);

        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToString(), options);
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class EcoscoreGradeConverter : JsonConverter<EcoscoreGrade>
    {
        public override bool CanConvert(Type t) => t == typeof(EcoscoreGrade);

        public override EcoscoreGrade Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == "a")
            {
                return EcoscoreGrade.A;
            }
            throw new Exception("Cannot unmarshal type EcoscoreGrade");
        }

        public override void Write(Utf8JsonWriter writer, EcoscoreGrade value, JsonSerializerOptions options)
        {
            if (value == EcoscoreGrade.A)
            {
                JsonSerializer.Serialize(writer, "a", options);
                return;
            }
            throw new Exception("Cannot marshal type EcoscoreGrade");
        }

        public static readonly EcoscoreGradeConverter Singleton = new EcoscoreGradeConverter();
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;
        public DateOnlyConverter() : this(null) { }

        public DateOnlyConverter(string? serializationFormat)
        {
                this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
                var value = reader.GetString();
                return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
                => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null) { }

        public TimeOnlyConverter(string? serializationFormat)
        {
                this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
                var value = reader.GetString();
                return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
                => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string? _dateTimeFormat;
        private CultureInfo? _culture;

        public DateTimeStyles DateTimeStyles
        {
                get => _dateTimeStyles;
                set => _dateTimeStyles = value;
        }

        public string? DateTimeFormat
        {
                get => _dateTimeFormat ?? string.Empty;
                set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
        }

        public CultureInfo Culture
        {
                get => _culture ?? CultureInfo.CurrentCulture;
                set => _culture = value;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
                string text;


                if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                        || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
                {
                        value = value.ToUniversalTime();
                }

                text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

                writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
                string? dateText = reader.GetString();

                if (string.IsNullOrEmpty(dateText) == false)
                {
                        if (!string.IsNullOrEmpty(_dateTimeFormat))
                        {
                                return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                        }
                        else
                        {
                                return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                        }
                }
                else
                {
                        return default(DateTimeOffset);
                }
        }


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
    }

