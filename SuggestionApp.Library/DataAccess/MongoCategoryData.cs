using Microsoft.Extensions.Caching.Memory;

namespace SuggestionApp.Library.DataAccess;

public class MongoCategoryData
{
	private readonly IMemoryCache _cache;
	private readonly IMongoCollection<CategoryModel> _categories;

	private const string _cacheName = "CategoryData";

	public MongoCategoryData(IDbConnection db, IMemoryCache cache)
	{
		_cache = cache;
		_categories = db.CategoryCollection;
	}

	public async Task<List<CategoryModel>> GetAllCategories()
	{
		var output = _cache.Get<List<CategoryModel>>(_cacheName);

		if (output is null)
		{
			var results = await _categories.FindAsync(_ => true);
			output = results.ToList();

			_cache.Set(_cacheName, output, TimeSpan.FromDays(1));
		}

		return output;
	}

	public Task CreateCategory(CategoryModel category)
	{
		return _categories.InsertOneAsync(category);
	}
}
