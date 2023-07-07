namespace MovieApp.Models.FeatureModels;
public class Actor_Movie
{
    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public int ActorId { get; set; }
    public virtual Actor Actor { get; set; }

}