using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;
using System.Data;

namespace CreateProblematicPdfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WIN_ANSI_ENCODING();
            UniJIS_UTF16_H();
        }

        static void UniJIS_UTF16_H()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 出力するPDFファイルのパス
            string outputPath = "UniJIS-UTF16-H.pdf";

            // 文字列
            var bytes =
                string.Concat(
                    Encoding.BigEndianUnicode.GetBytes("Ｔｈｉｓ ｉｓ ａ ｔｅｓｔ ＰＤＦ！").Select(it => it.ToString("X2"))
                );

            // フォントの設定

            // PDFドキュメントの作成
            Document document = new Document();
            document.SetPageSize(new RectangleReadOnly(842f, 595f));
            // PDFライターの作成
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
            // ドキュメントを開く
            document.Open();

            writer.DirectContent.BeginText();
            writer.DirectContent.SetTextMatrix(1, 0, 0, 1, 100, 595 - 100f - 30);
            writer.DirectContent.SetColorFill(Color.BLACK);
            writer.DirectContent.SetColorStroke(Color.BLACK);
            writer.DirectContent.SetCharacterSpacing(0);
            writer.DirectContent.InternalBuffer.Append("/Font1 30 Tf <" + bytes + ">Tj\n");
            writer.DirectContent.EndText();
            var font1 = new PdfDictionary();
            font1.Put(PdfName.BASEFONT, new PdfName("MS-Mincho"));
            font1.Put(PdfName.ENCODING, new PdfName("UniJIS-UTF16-H"));
            font1.Put(PdfName.NAME, new PdfName("Font1"));
            font1.Put(PdfName.SUBTYPE, PdfName.TYPE0);
            font1.Put(PdfName.TYPE, PdfName.FONT);
            {
                var cidSI = new PdfDictionary();
                {
                    cidSI.Put(PdfName.REGISTRY, new PdfString("Adobe"));
                    cidSI.Put(PdfName.ORDERING, new PdfString("Japan1"));
                    cidSI.Put(PdfName.SUPPLEMENT, new PdfNumber(6));
                }
                var w = new PdfArray();
                w.Add(new PdfNumber(231));
                w.Add(new PdfNumber(465));
                w.Add(new PdfNumber(500));
                w.Add(new PdfNumber(631));
                w.Add(new PdfArray(new int[] { 500 }));
                var fontCid = new PdfDictionary();
                fontCid.Put(PdfName.BASEFONT, new PdfName("MS-Mincho"));
                fontCid.Put(PdfName.CIDSYSTEMINFO, cidSI);
                fontCid.Put(PdfName.DW, new PdfNumber(1000));
                fontCid.Put(PdfName.SUBTYPE, PdfName.CIDFONTTYPE0);
                fontCid.Put(PdfName.TYPE, PdfName.FONT);
                fontCid.Put(PdfName.W, w);
                {
                    var fontDescriptorDict = new PdfDictionary();
                    fontDescriptorDict.Put(PdfName.ASCENT, new PdfNumber(859));
                    fontDescriptorDict.Put(PdfName.CAPHEIGHT, new PdfNumber(709));
                    fontDescriptorDict.Put(PdfName.DESCENT, new PdfNumber(-140));
                    fontDescriptorDict.Put(PdfName.FLAGS, new PdfNumber(7));
                    fontDescriptorDict.Put(PdfName.FONTBBOX, new PdfArray(new int[] { 0, -137, 1000, 859 }));
                    fontDescriptorDict.Put(PdfName.FONTNAME, new PdfName("MS-Mincho"));
                    fontDescriptorDict.Put(PdfName.ITALICANGLE, new PdfNumber(0));
                    fontDescriptorDict.Put(new PdfName("StemH"), new PdfNumber(34));
                    fontDescriptorDict.Put(PdfName.STEMV, new PdfNumber(69));
                    fontDescriptorDict.Put(PdfName.TYPE, PdfName.FONTDESCRIPTOR);
                    fontDescriptorDict.Put(new PdfName("XHeight"), new PdfNumber(450));
                    fontCid.Put(PdfName.FONTDESCRIPTOR, writer.AddToBody(fontDescriptorDict).IndirectReference);
                }
                font1.Put(PdfName.DESCENDANTFONTS, new PdfArray(
                    writer.AddToBody(fontCid).IndirectReference
                ));
            }
            var fontDict = new PdfDictionary();
            fontDict.Put(new PdfName("Font1"), writer.AddToBody(font1).IndirectReference);
            var procSetDict = new PdfArray();
            procSetDict.Add(PdfName.PDF);
            procSetDict.Add(PdfName.TEXT);
            var resourcesDict = new PdfDictionary();
            resourcesDict.Put(PdfName.FONT, fontDict);
            resourcesDict.Put(PdfName.PROCSET, procSetDict);
            writer.AddPageDictEntry(PdfName.RESOURCES, writer.AddToBody(resourcesDict).IndirectReference);

            // ドキュメントを閉じる
            document.Close();

            Console.WriteLine("PDFを出力しました: " + outputPath);

        }

        static void WIN_ANSI_ENCODING()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // 出力するPDFファイルのパス
            string outputPath = "WIN_ANSI_ENCODING.pdf";

            // 文字列
            var ansiBytes =
                string.Concat(
                    Encoding.GetEncoding(932).GetBytes("This is a test PDF!").Select(it => it.ToString("X2"))
                );

            // フォントの設定

            // PDFドキュメントの作成
            Document document = new Document();
            document.SetPageSize(new RectangleReadOnly(842f, 595f));
            // PDFライターの作成
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
            // ドキュメントを開く
            document.Open();

            writer.DirectContent.BeginText();
            writer.DirectContent.SetTextMatrix(1, 0, 0, 1, 100, 595 - 100f - 30);
            writer.DirectContent.SetColorFill(Color.BLACK);
            writer.DirectContent.SetColorStroke(Color.BLACK);
            writer.DirectContent.SetCharacterSpacing(0);
            writer.DirectContent.InternalBuffer.Append("/Font1 30 Tf <" + ansiBytes + ">Tj\n");
            writer.DirectContent.EndText();
            var font1 = new PdfDictionary();
            font1.Put(PdfName.BASEFONT, new PdfName("MS-PGothic"));
            font1.Put(PdfName.ENCODING, PdfName.WIN_ANSI_ENCODING);
            font1.Put(PdfName.FIRSTCHAR, new PdfNumber(32));
            font1.Put(PdfName.LASTCHAR, new PdfNumber(255));
            font1.Put(PdfName.NAME, new PdfName("Font1"));
            font1.Put(PdfName.SUBTYPE, PdfName.TRUETYPE);
            font1.Put(PdfName.TYPE, PdfName.FONT);
            font1.Put(PdfName.WIDTHS, new PdfArray("305 219 500 500 500 500 594 203 305 305 500 500 203 500 203 500 500 500 500 500 500 500 500 500 500 500 203 203 500 500 500 453 668 633 637 664 648 566 551 680 641 246 543 598 539 742 641 707 617 707 625 602 590 641 633 742 602 590 566 336 504 336 414 305 414 477 496 500 496 500 305 461 500 211 219 461 211 734 500 508 496 496 348 461 352 500 477 648 461 477 457 234 234 234 414 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 441 441 441 441 441 547 523 445 480 469 516 523 504 438 500 641 617 566 625 598 637 563 652 539 621 523 664 590 637 645 555 527 602 602 602 461 645 598 578 648 492 637 516 547 613 641 605 453 660 508 609 664 641 520 559 512 656 566 559 590 563 250 230 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0".Split(' ').Select(int.Parse).ToArray()));
            {
                var fontDescriptorDict = new PdfDictionary();
                fontDescriptorDict.Put(PdfName.ASCENT, new PdfNumber(859));
                fontDescriptorDict.Put(PdfName.CAPHEIGHT, new PdfNumber(859));
                fontDescriptorDict.Put(PdfName.DESCENT, new PdfNumber(-141));
                fontDescriptorDict.Put(PdfName.FLAGS, new PdfNumber(34));
                fontDescriptorDict.Put(PdfName.FONTBBOX, new PdfArray(new int[] { -977, -137, 996, 859 }));
                fontDescriptorDict.Put(PdfName.FONTNAME, new PdfName("MS-PGothic"));
                fontDescriptorDict.Put(PdfName.ITALICANGLE, new PdfNumber(0));
                fontDescriptorDict.Put(PdfName.STEMV, new PdfNumber(500));
                fontDescriptorDict.Put(PdfName.TYPE, PdfName.FONTDESCRIPTOR);
                font1.Put(PdfName.FONTDESCRIPTOR, writer.AddToBody(fontDescriptorDict).IndirectReference);
            }
            var fontDict = new PdfDictionary();
            fontDict.Put(new PdfName("Font1"), writer.AddToBody(font1).IndirectReference);
            var procSetDict = new PdfArray();
            procSetDict.Add(PdfName.PDF);
            procSetDict.Add(PdfName.TEXT);
            var resourcesDict = new PdfDictionary();
            resourcesDict.Put(PdfName.FONT, fontDict);
            resourcesDict.Put(PdfName.PROCSET, procSetDict);
            writer.AddPageDictEntry(PdfName.RESOURCES, writer.AddToBody(resourcesDict).IndirectReference);

            // ドキュメントを閉じる
            document.Close();

            Console.WriteLine("PDFを出力しました: " + outputPath);
        }
    }
}
