namespace AlgorithmTests
{
    public class TestCaseMatrix<TInput, TParam, TResult> 
        where TInput : struct
        where TResult : struct
        where TParam: struct
    {
        public TInput[][] Input { get; set; }

        public TResult Result { get; set; }

        public TParam Param { get; set; }
    }

    public class TestCaseMatrix<TInput, TResult>
        where TInput : struct
        where TResult : struct
    {
        public TInput[][] Input { get; set; }

        public TResult Result { get; set; }
    }
}
