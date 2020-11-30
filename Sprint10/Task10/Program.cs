using System;
using System.IO;
//Suppose we need to work on an error logging module that logs exception stack traces into a file. You see this solution in the answer box preload.

//The following are the classes that provide functionality to log a stack trace into a file. Among this it provide the storage of this stack trace in a database if an IO exception occurs.

//But whenever the client wants to introduce a new logger, we need to alter ExceptionLogger by adding a new method.If we continue doing this after some time then we will see a fat ExceptionLogger class with a large set of methods that provide the functionality to log a message into various targets. 

//Why does this issue occur? Because ExceptionLogger directly contacts the low-level classes FileLogger and DbLogger to log the exception. We need to alter the design so that this ExceptionLogger class can be loosely coupled with those class. To do that we need to introduce an abstraction between them, so that ExcetpionLogger can contact the abstraction to log the exception instead of depending on the low-level classes directly.
//Your task is to refactor solution. You have to move to the low-level class’s initiation from the ExcetpionLogger class to the DataExporter class to make ExceptionLogger loosely coupled with the classes FileLogger and DBLogger. And by doing that we are giving provision to DataExporter class to decide what kind of Logger should be called based on the exception that occurs.
namespace Task10
{
    public interface ILogger
    {
        void LogMessage(string v);
    }
    public class DbLogger : ILogger
    {
        public void LogMessage(string mMessage)
        {
            //Code to write message in database.  
        }
    }
    public class FileLogger : ILogger
    {
        public void LogMessage(string mStackTrace)
        {
            //code to log stack trace into a file.  
        }
    }
    public class ExceptionLogger
    {
        private ILogger logger;
        public ExceptionLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public void LogException(Exception ex)
        {
            logger.LogMessage(GetUserReadableMessage(ex));
        }
        private string GetUserReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;
            //code to convert Exception's stack trace and message to user   
            // readable format.  
            return strMessage;
        }
    }

    public class DataExporter
    {
        public void ExportDataFromFile()
        {
            try
            {
                //code to export data from files to database.  
            }
            catch (IOException ex)
            {
                new ExceptionLogger(new DbLogger()).LogException(ex);
            }
            catch (Exception ex)
            {
                new ExceptionLogger(new FileLogger()).LogException(ex);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var log = new DbLogger();
            ExceptionLogger exception = new ExceptionLogger(log);
            
            Console.WriteLine("Hello World!");
        }
    }
}
