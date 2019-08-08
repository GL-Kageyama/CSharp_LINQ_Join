using System;
using System.Linq;
using System.Collections.Generic;

namespace Join
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var join = new JoinClass();

			join.GetJoin();
		}
	}

	class JoinClass
	{
		public void GetJoin()
		{
			var outer1 = new[] 
			{
				new {Name = "Kana", Age = 11}, 
				new {Name = "Yukiko", Age = 21}, 
				new {Name = "Taichi", Age = 65}, 
				new {Name = "Syuuichi", Age = 43}, 
				new {Name = "Gen", Age = 21}, 
			};

			var outer2 = new[] 
			{
				new {Name = "Isamu", Age = 72}, 
				new {Name = "Yuki", Age = 28}, 
			};

			var inner = new[]
			{
				new {Name = "Isamu", comeFrom = "Kyoto"}, 
				new {Name = "Kana", comeFrom = "Gihu"}, 
				new {Name = "Gen", comeFrom = "Kanagawa"}, 
			};

			// 空集合
			IEnumerable<decimal> empty = Enumerable.Empty<decimal>();

			// Join()
			// 内部結合を行う
			var query = outer1.Join(inner,
				                    e => e.Name,
				                    n => n.Name,
				                    (e, n) => new {e.Name, e.Age, n.comeFrom});
			foreach (var fri in query)
				Console.WriteLine(fri);
			Console.WriteLine();

			// Concat()
			// 2つのシーケンスを連結
			var query2 = outer1.Concat(outer2);
			foreach (var fri2 in query2)
				Console.WriteLine(fri2);
			Console.WriteLine();

			// DefaultIfEmpty()
			// シーケンスを取得 or 空ならば規定値を取得
			var query3 = outer1.DefaultIfEmpty();
			foreach (var fri3 in query3)
				Console.WriteLine(fri3);
			Console.WriteLine();
			// 空集合の場合
			var query4 = empty.DefaultIfEmpty();
			foreach (var em in query4)
				Console.WriteLine(em);
			Console.WriteLine();

			// Zip()
			// 指定した関数で、2つのシーケンスを1つにマージ
			var query5 = outer1.Zip(outer2, (a1, a2) => a1.Name + " & " + a2.Name);
			foreach (var nameZ in query5)
				Console.WriteLine(nameZ);
			Console.WriteLine();
		}
	}
}

