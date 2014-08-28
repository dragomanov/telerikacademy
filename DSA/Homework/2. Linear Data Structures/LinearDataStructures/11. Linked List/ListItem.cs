namespace LinearDataStructures
{
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> NextItem;

        public ListItem(T value)
            :this(value, null)
        {
        }

        public ListItem(T value, ListItem<T> item)
        {
            this.value = value;
            this.NextItem = item;
        }
    }
}
