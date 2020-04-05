using System;
using Utilities;
using System.Data.SqlClient;

namespace Item46_UtilizeUsingAndTryFinallyForResourceCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowsHowTheUsingStatementGeneratesTryFinallyBlock();
            UsingManualTryFinallyBlockWhenHavingTwoOrMoreDisposableObjects();
            UsingAsClauseIfNotSureTheObjectIsDisposable();
        }

        private static void UsingAsClauseIfNotSureTheObjectIsDisposable()
        {
            /*
             If obj implements IDisposable, 
             the using statement generates the cleanup code. If not, 
             the using statement degenerates to using(null), 
             which is safe but doesn’t do anything.*/

            var obj = new object();
            using (obj as IDisposable)
            {
                
            }
        }

        private static void UsingManualTryFinallyBlockWhenHavingTwoOrMoreDisposableObjects()
        {
            var con = new SqlConnection();
            var com = new SqlCommand("",con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            finally
            {
                com.Dispose();
                con.Dispose();
            }
        }

        private static void ShowsHowTheUsingStatementGeneratesTryFinallyBlock()
        {
            // wraps the code in a try/finally block, and calls the con.Dispose()
            using (var con = new SqlConnection())
            {
                con.Open();
                con.Close();
            }

            // similar to below
            var con_2 = new SqlConnection(); ;
            try
            {
                con_2.Open();
                con_2.Close();
            }
            finally
            {
                con_2.Dispose();
            }
        }
    }
}
