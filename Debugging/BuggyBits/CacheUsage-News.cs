  public IActionResult Index()
  {
      string key = Guid.NewGuid().ToString();
      var cachedResult = cache.GetOrCreate(key, cacheEntry => {
          cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
          cacheEntry.RegisterPostEvictionCallback(CacheRemovedCallback);
          cacheEntry.Priority = CacheItemPriority.NeverRemove;

          return new string("New site launched 2008-02-02");
      });

      var news = new List<News>
      {
          new News() { Title = cachedResult }
      };
      return View(news);
  }