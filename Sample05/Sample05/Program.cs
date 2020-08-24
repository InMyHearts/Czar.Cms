using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample05
{
    class Program
    {
        const string connectString = "Data Source=.;User ID=sa;Password=123123;Initial Catalog=Test;Pooling=true;Max Pool Size=100;";

        static void Main(string[] args)
        {
            //TestInsert();
            //TestMultInsert();
            TestDel();
            TestMultDel();
            Console.WriteLine("Hello World!");
        }

        static void TestInsert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1"
            };
            using var conn = new SqlConnection(connectString);
            string sql_Insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
                VALUES (@title,@content,@status,@add_time,@modify_time)";
            var result = conn.Execute(sql_Insert, content);
            Console.WriteLine($"test_insert：插入了{result}条数据！");
        }

        static void TestMultInsert()
        {
            List<Content> contents = new List<Content>()
            {
                new Content
                {
                    title = "批量插入标题1",
                    content = "批量插入内容1",

                },
               new Content
                {
                    title = "批量插入标题2",
                    content = "批量插入内容2",
                },
            };

            using var conn = new SqlConnection(connectString);
            string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
                VALUES (@title,@content,@status,@add_time,@modify_time)";
            var result = conn.Execute(sql_insert, contents);
            Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
        }

        static void TestDel()
        {
            var content = new Content
            {
                id = 4
            };
            using var conn = new SqlConnection(connectString);
            var sql_delete = @"delete from content where id=@id";
            var result = conn.Execute(sql_delete, content);
            Console.WriteLine($"test_del：删除了{result}条数据！");
        }

        static void TestMultDel()
        {
            var contents = new List<Content>
            {
               new Content
               {
                   id = 5
               },
               new Content
               {
                   id = 6
               },
            };
            using var conn = new SqlConnection(connectString);
            var sql_delete = @"delete from content where id=@id";
            var result = conn.Execute(sql_delete, contents);
            Console.WriteLine($"test_mult_del：删除了{result}条数据！");
        }
    }
}
