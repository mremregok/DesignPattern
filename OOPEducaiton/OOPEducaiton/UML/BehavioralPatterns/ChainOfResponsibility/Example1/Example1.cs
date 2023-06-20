using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.ChainOfResponsibility.Example1
{
	public class Document
	{
		public string TextContent { get; set; }
		public int Id { get; set; }
	}

	public class ReviewResult
	{
		public bool Approved { get; set; }
		public string Reviewer { get; set; }
	}
	public interface IEditor
	{
		ReviewResult ReviewDocument(Document document);
	}

	public class Editor : IEditor
	{
		public IEditor Successor { get; private set; }

		public Editor(IEditor successor)
		{
			Successor = successor;
		}

		public ReviewResult ReviewDocument(Document document)
		{
			ReviewResult result = new ReviewResult()
			{
				Reviewer = "Editor"
			};
			if (!string.IsNullOrWhiteSpace(document.TextContent))
			{
				if (document.TextContent.Length > 1000)
					return Successor.ReviewDocument(document);
				if (document.TextContent.Length >= 600)
					result.Approved = true;
			}
			return result;
		}
	}

	public class ExecutiveEditor : IEditor
	{
		public IEditor Successor { get; private set; }
		public ExecutiveEditor(IEditor successor)
		{
			Successor = successor;
		}

		public ReviewResult ReviewDocument(Document document)
		{
			ReviewResult result = new ReviewResult()
			{
				Reviewer = "Executive Editor"
			};
			if (!string.IsNullOrWhiteSpace(document.TextContent))
			{
				if (document.TextContent.Length > 2000)
					return Successor.ReviewDocument(document);
				if (document.TextContent.Length <= 1500)
					result.Approved = false;
				if (document.TextContent.Length > 1500)
					result.Approved = true;
			}
			return result;
		}
	}

	public class ManagingEditor : IEditor
	{
		public ReviewResult ReviewDocument(Document document)
		{
			ReviewResult result = new ReviewResult()
			{
				Reviewer = "Managing Editor"
			};
			result.Approved = !string.IsNullOrWhiteSpace(document.TextContent) && document.TextContent.Length > 2000;
			return result;
		}
	}

	public class CORExample1Runner
	{
		public CORExample1Runner()
		{
			List<Document> documents = new List<Document>()
				{
					new Document() { Id = 1, TextContent = new string('*', 500)},
					new Document() { Id = 2, TextContent = new string('*', 850)},
					new Document() { Id = 3, TextContent = new string('*', 1500)},
					new Document() { Id = 4, TextContent = new string('*', 2500) }
				};

			IEditor editor = new Editor(new ExecutiveEditor(new ManagingEditor()));
			documents.ForEach(x =>
			{
				var result = editor.ReviewDocument(x);
				Console.WriteLine(result.Approved ? "Document {0} approved by {1}"
					: "Document {0} rejected by {1}",
								  x.Id, result.Reviewer);
			});
			Console.Read();
		}
	}
}

