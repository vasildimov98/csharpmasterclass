public static class TupleSwapExercise<T1, T2>
{
    public static Tuple<T2, T1> SwapTupleItems<T1, T2>(Tuple<T1, T2> item)
    {
        return new Tuple<T2, T1>(item.Item2, item.Item1);
    }
}