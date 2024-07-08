namespace GW2CraftCalculator.Logic.ViewModelCreators;
public class GroupingRecipeCreator<TGroupingKey, TGroupItem> : ItemViewDefaultCreator
    where TGroupingKey : class
    where TGroupItem : class
{
    public GroupingRecipeCreator(ItemViewDefaultCreator creator, IEnumerable<TGroupItem> input, Func<TGroupItem, TGroupingKey> groupingSelector) : base(creator)
    {
        Input = input;
        GroupingSelector = groupingSelector;
    }

    public IEnumerable<TGroupItem> Input { get; init; }
    public Func<TGroupItem, TGroupingKey> GroupingSelector { get; init; }
    public Func<TGroupItem, bool>? WhereSelector { get; set; }

    public IEnumerable<IGrouping<TGroupingKey, TGroupItem>> Group()
    {
        IEnumerable<TGroupItem> filteredInput = Input;

        if (WhereSelector != null)
        {
            filteredInput = Input.Where(WhereSelector);
        }

        IEnumerable<IGrouping<TGroupingKey, TGroupItem>> groupedInput = filteredInput.GroupBy(GroupingSelector);
        return groupedInput;
    }
}
