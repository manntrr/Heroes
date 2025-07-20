using System.Collections.Immutable;

namespace Heroes;

public class GenreKeySet : HashSet<String>
{
    public String[] Keys { get => this.ToArray<String>(); }
    public GenreKeySet(Genres Genres, ref Genres MasterGenres)
    {
        base.UnionWith(Genres.Keys);
        foreach (String key in this.Except(MasterGenres.Keys))
        {
            MasterGenres.Add(key, Genres[key]);
        }
    }
    public GenreKeySet(GenreKeySet Original)
    {
        foreach (String key in Original)
        {
            base.Add(key);
        }
    }
    public Genres Genres(Genres MasterGenres, bool throwIfMissingInMaster = true)
    {
        Genres result = [];
        GenreKeySet masterKeySet = new(MasterGenres, ref MasterGenres);
        GenreKeySet missingKeySet = new GenreKeySet(MasterGenres, ref MasterGenres);
        missingKeySet.Clear();
        missingKeySet.UnionWith(this.Except(masterKeySet));
        if (missingKeySet.Count > 0 && throwIfMissingInMaster) throw new ArgumentOutOfRangeException(nameof(MasterGenres), missingKeySet, "Missing keys in the Master list!");
        Genres intersectedGenres = new Genres();
        intersectedGenres.Clear();
        foreach (var key in masterKeySet.Intersect(this))
        {
            intersectedGenres.Add(key, MasterGenres[key]);
        }
        result.Clear();
        GenreKeySet resultKeySet = new GenreKeySet(intersectedGenres, ref MasterGenres);
        foreach (String key in resultKeySet)
        {
            result.Add(MasterGenres[key]);
        }
        return result;
    }
}
