using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;



namespace aspectJ
{
    /// <summary>
    /// treeGraph.xaml 的交互逻辑
    /// </summary>

    public partial class treeGraph : Window
    {

        public const double vDelta = 90;
        public const double hDelta = 160;
        List<Piece> pieces = new List<Piece>();
        TreeControl tc;
        
        public treeGraph()
        {
            InitializeComponent();
            AnalyseFuction af = new AnalyseFuction("./test.txt");
            af.readFile();
            pieces = af.getPieceList();

            //pieces[1].isHidden = true;
            //pieces[2].isHidden = true;
            //pieces[81].isHidden = true;
            //pieces[61].isHidden = true;

           // pieces[1].isHighlight = true;

            tc = new TreeControl(drawingSurface,pieces);
            //tc.setBranchHidden(86);
            //tc.setBranchHidden("fillColor");
            tc.drawTree();
           
            scrollViewer.ScrollToHorizontalOffset(pieces[0].topLeftCorner.X - this.Width/2 - 75);
        }

        private void drawingSurface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pointClicked = e.GetPosition(drawingSurface);
            tc.setChildHidden(pointClicked,ref scrollViewer);
        }

        private void drawingSurface_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pointClicked = e.GetPosition(drawingSurface);
            int position = tc.visualPos(pointClicked);
            if (position != -1)
            {
                elementBox eb = new elementBox(position, tc, ref scrollViewer);
                eb.Top = this.Top + e.GetPosition(this).Y;
                eb.Left = this.Left + e.GetPosition(this).X;
                eb.Owner = this;
                eb.setText(pieces[position].className, pieces[position].functionName);
                eb.Show();
            }
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	tc.refresh();// 在此处添加事件处理程序实现。
        }

        private void functionDropButton_Click(object sender, RoutedEventArgs e)
        {
            theMainWindow tmw = new theMainWindow();
            tmw.Show();
            this.Close();
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }



    //定义DrawingCanvas
    public class DrawingCanvas : Canvas
    {
        private List<Visual> visuals = new List<Visual>();


        protected override int VisualChildrenCount
        {
            get { return visuals.Count; }

        }

        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);
            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
            
        }

        public void DeleteVisual(Visual visual)
        {
            visuals.Remove(visual);

            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }

        public void clear()
        {
            for (int i = 0; i < visuals.Count; i++)
            {
                base.RemoveVisualChild(visuals[i]);
                base.RemoveLogicalChild(visuals[i]);
            }
            visuals.Clear();
        }

        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;
        }
    }

    //定义画布绘画控制类DrawControl
    public class DrawControl
    {
        //private static LinearGradientBrush nameRectBrush = new LinearGradientBrush(Color.FromRgb(75, 208, 255), Color.FromRgb(0, 170, 230), 90.0); //类名矩形颜色
        private static SolidColorBrush classRectBrush = new SolidColorBrush(Color.FromRgb(0, 173, 230) ); //类名矩形颜色 0,170,230  51,153,255
        private static SolidColorBrush containRectBrush = new SolidColorBrush(Color.FromRgb(31, 78, 121)); //contain类名矩形
        private static SolidColorBrush highlightRectBrush = new SolidColorBrush(Colors.Khaki );
        private static SolidColorBrush functionRectBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255) );//函数名矩形颜色
        private static SolidColorBrush nameBrush = new SolidColorBrush(Color.FromRgb(70, 70, 70));//函数名颜色
        private static Pen linePen = new Pen(Brushes.LightGray, 4);//连接线的颜色和粗细
        private static Size classRectSize = new Size(130, 40);//函数名矩形大小 
        private static Size functionRectSize =new Size(130, 40);//类名矩形大小
        private static double radiusX = 4, radiusY = 4;//矩形圆弧
        private static double classDeltaX = 3, classDeltaY = 3;//类名文字偏移量
        private static double functionDeltaX1 = 3, functionDeltaY1 = 36;//函数名文字偏移量
        private static double functionDeltaX2 = 3, functionDeltaY2 = 26;//函数名文字偏移量
        private static double functionDeltaX3 = 3, functionDeltaY3 = 46;//函数名文字偏移量
        private static double rectDeltaY = 25;//函数名矩形下移量
        private DrawingCanvas drawcanvas;//作画的画布


        public DrawControl(DrawingCanvas _drawcanvas)
        {
            drawcanvas = _drawcanvas;
        }

        public DrawingVisual addBlock(Point topLeftCorner, String className, String functionName)//添加函数名方块
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawRoundedRectangle(classRectBrush, null, new Rect(topLeftCorner, classRectSize), radiusX, radiusY);
                dc.DrawRoundedRectangle(functionRectBrush, null, new Rect(new Point(topLeftCorner.X, topLeftCorner.Y + rectDeltaY), functionRectSize), radiusX, radiusY);
                dc.DrawText(
                    new FormattedText(className,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        15, Brushes.White),
                        new Point(topLeftCorner.X + classDeltaX, topLeftCorner.Y + classDeltaY));

                if (true)
                {
                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, nameBrush),
                            new Point(topLeftCorner.X + functionDeltaX1, topLeftCorner.Y + functionDeltaY1));
                }
                else
                {
                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX2, topLeftCorner.Y + functionDeltaY2));

                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX3, topLeftCorner.Y + functionDeltaY3));
                }
            }
                
            drawcanvas.AddVisual(visual);
            return visual;
        }

        public DrawingVisual addHighlightBlock(Point topLeftCorner, String className, String functionName)//添加函数名方块
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawRoundedRectangle(highlightRectBrush, null, new Rect(topLeftCorner, classRectSize), radiusX, radiusY);
                dc.DrawRoundedRectangle(functionRectBrush, null, new Rect(new Point(topLeftCorner.X, topLeftCorner.Y + rectDeltaY), functionRectSize), radiusX, radiusY);
                dc.DrawText(
                    new FormattedText(className,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        15, Brushes.White),
                        new Point(topLeftCorner.X + classDeltaX, topLeftCorner.Y + classDeltaY));

                if (true)
                {
                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, nameBrush),
                            new Point(topLeftCorner.X + functionDeltaX1, topLeftCorner.Y + functionDeltaY1));
                }
                else
                {
                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX2, topLeftCorner.Y + functionDeltaY2));

                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX3, topLeftCorner.Y + functionDeltaY3));
                }
            }

            drawcanvas.AddVisual(visual);
            return visual;
        }

        public DrawingVisual addContainBlock(Point topLeftCorner, String className, String functionName)//添加contain函数名方块
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawRoundedRectangle(containRectBrush, null, new Rect(topLeftCorner, classRectSize), radiusX, radiusY);
                dc.DrawRoundedRectangle(functionRectBrush, null, new Rect(new Point(topLeftCorner.X, topLeftCorner.Y + rectDeltaY), functionRectSize), radiusX, radiusY);
                dc.DrawText(
                    new FormattedText("+" + className,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        15, Brushes.White),
                        new Point(topLeftCorner.X + classDeltaX, topLeftCorner.Y + classDeltaY));

                if (true)
                {
                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX1, topLeftCorner.Y + functionDeltaY1));
                }
                else
                {
                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX2, topLeftCorner.Y + functionDeltaY2));

                    dc.DrawText(
                        new FormattedText(functionName,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            15, Brushes.Black),
                            new Point(topLeftCorner.X + functionDeltaX3, topLeftCorner.Y + functionDeltaY3));
                }
            }

            drawcanvas.AddVisual(visual);
            return visual;
        }

        public Point calculateBlock(Point topLeftCorner, String className, String functionName)//计算函数方块中心
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawRoundedRectangle(classRectBrush, null, new Rect(topLeftCorner, classRectSize), radiusX, radiusY);
                dc.DrawRoundedRectangle(functionRectBrush, null, new Rect(new Point(topLeftCorner.X, topLeftCorner.Y + rectDeltaY), functionRectSize), radiusX, radiusY);
            }

            return new Point((visual.ContentBounds.Left + visual.ContentBounds.Right) / 2, (visual.ContentBounds.Top + visual.ContentBounds.Bottom) / 2);
        }

        public void addCenterLine(Point point1, Point point2)//添加连接线
        {
            DrawingVisual visual = new DrawingVisual();

            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawLine(linePen, point1, point2);
            }

            drawcanvas.AddVisual(visual);
        }
    }

    

    public class TreeControl
    {
        private List<Piece> pieces;
        private Stack<int> stack;
        private Stack<int> shiftStack;
        private List<double> mostRight;
        private int  now, maxDepth;
        private DrawingCanvas drawingCanvas;
        private Dictionary<DrawingVisual, int> visualDict;
        private bool isHidding;
        private int root;

        public TreeControl(DrawingCanvas _drawingCanvas ,List<Piece> _pieces)
        {
            drawingCanvas = _drawingCanvas;
            pieces = new List<Piece>(_pieces);
            visualDict = new Dictionary<DrawingVisual, int>();
            stack = new Stack<int>();
            shiftStack = new Stack<int>();
            mostRight = new List<double>();
        }

        public void drawTree()
        {
            
            calculate();
            drawTreeGraph();
        }

        public void refresh()
        {
            visualDict.Clear();
            drawingCanvas.clear();
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].isChildTreeHidden = false;
                pieces[i].isHidden = false;
                pieces[i].isHighlight = false;
            }
            calculate();
            drawTreeGraph();
        }

        public void setChildHidden(Point point, ref ScrollViewer scrollviewer)
        {
            DrawingVisual visual = drawingCanvas.GetVisual(point);
            if (visual != null && visualDict.ContainsKey(visual))
            {
                if ( !(pieces[visualDict[visual]].isChildTreeHidden==false&& pieces[visualDict[visual]].sonNum == 0) )
                {
                    pieces[visualDict[visual]].isChildTreeHidden = !pieces[visualDict[visual]].isChildTreeHidden;
                    int it = visualDict[visual];
                    visualDict.Clear();
                    drawingCanvas.clear();
                    double preX = pieces[it].topLeftCorner.X;
                    calculate();
                    double nowX = pieces[it].topLeftCorner.X;
                    if (scrollviewer.HorizontalOffset - preX + nowX >= 0)
                        scrollviewer.ScrollToHorizontalOffset(scrollviewer.HorizontalOffset - preX + nowX);
                    else
                        shiftChildTree(-1, pieces.Count, preX - nowX);
                    drawTreeGraph();


                    double maxMostRight = 0;
                    for (int i = 0; i < mostRight.Count; i++)
                    {
                        if (maxMostRight < mostRight[i])
                            maxMostRight = mostRight[i];
                    }
                    if (drawingCanvas.Width < maxMostRight + Constant.hDelta)
                        drawingCanvas.Width = maxMostRight + Constant.hDelta;
                    if (drawingCanvas.Height < (maxDepth) * Constant.vDelta)
                        drawingCanvas.Height = (maxDepth) * Constant.vDelta;
                }
            }
        }

        public void BranchHidden(int position, bool isFunctionHidden, ref ScrollViewer scrollviewer)
        {

            if (isFunctionHidden)
            {
                setBranchHidden(pieces[position].functionName);
            }
            else
            {
                setBranchHidden(position);
            }
                    visualDict.Clear();
                    drawingCanvas.clear();
                    double preX = pieces[position].topLeftCorner.X;
                    calculate();
                    double nowX = pieces[position].topLeftCorner.X;
                    if (scrollviewer.HorizontalOffset - preX + nowX >= 0)
                        scrollviewer.ScrollToHorizontalOffset(scrollviewer.HorizontalOffset - preX + nowX);
                    else
                        shiftChildTree(-1, pieces.Count, preX - nowX);
                    drawTreeGraph();

                    double maxMostRight = 0;
                    for (int i = 0; i < mostRight.Count; i++)
                    {
                        if (maxMostRight < mostRight[i])
                            maxMostRight = mostRight[i];
                    }
                    if (drawingCanvas.Width < maxMostRight + Constant.hDelta)
                        drawingCanvas.Width = maxMostRight + Constant.hDelta;
                    if (drawingCanvas.Height < (maxDepth) * Constant.vDelta)
                        drawingCanvas.Height = (maxDepth) * Constant.vDelta;
        }

        private void setBranchHidden(int pos)
        {
            now = 0;
            stack.Clear();
            isHidding = true;
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].status == true)
                {
                    stack.Push(i);
                    pieces[i].isHighlight = false;
                    if (i == pos)
                    {
                        isHidding = false;
                        pieces[i].isHighlight = true;
                    }
                    pieces[i].isHidden = isHidding;
                }
                else
                {
                    now = stack.Pop();
                    if (now == pos)
                    {
                        foreach (int ancient in stack)
                        {
                            pieces[ancient].isHidden = isHidding;
                        }
                        isHidding = true;
                    }
                }
            }//for
            while (stack.Count != 0)
            {
                now = stack.Pop();
                if (now == pos)
                {
                    foreach (int ancient in stack)
                    {
                        pieces[ancient].isHidden = isHidding;
                    }
                    isHidding = true;
                }
            }
        
        }

        private void setBranchHidden(string functionName)
        {
            now = 0;
            stack.Clear();
            isHidding = true;
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].status == true)
                {
                    stack.Push(i);
                    pieces[i].isHighlight = false;
                    if (pieces[i].functionName == functionName) 
                    {
                        pieces[i].isHighlight = true;
                        if (isHidding == true)
                        {
                            root = i;
                            isHidding = false;
                        }
                       
                    }
                    pieces[i].isHidden = isHidding;
                }
                else
                {
                    now = stack.Pop();
                    if (now ==root)
                    {
                        foreach (int ancient in stack)
                        {
                            pieces[ancient].isHidden = isHidding;
                        }
                        isHidding = true;
                    }
                }
            }//for
            while (stack.Count != 0)
            {
                now = stack.Pop();
                if (now == root)
                {
                    foreach (int ancient in stack)
                    {
                        pieces[ancient].isHidden = isHidding;
                    }
                    isHidding = true;
                }
            }

        }


        public int visualPos(Point point)
        {
            DrawingVisual visual = drawingCanvas.GetVisual(point);
            if (visual != null && visualDict.ContainsKey(visual))
            {
                return visualDict[visual];
            }
            else
            {
                return -1;
            }
        }

        public double MaxBound(int depth, bool isLeaf)
        {
            double maxBound=mostRight[depth];
            if (isLeaf && mostRight.Count > depth + 1 && mostRight[depth + 1] > maxBound)
            {
                maxBound = mostRight[depth + 1];
            }
            if (depth - 1 >= 0 && mostRight[depth - 1] > maxBound)
            {
                maxBound = mostRight[depth - 1];
            }
            return maxBound;
        }

        private void shiftChildTree(int start, int end, double delta)//子树不平移
        {
            for (int i = start + 1; i < end; i++)
            {

                if (pieces[i].status == true)
                {
                    pieces[i].topLeftCorner.X += delta;
                    if (mostRight[pieces[i].depth] < pieces[i].topLeftCorner.X)
                    {
                        mostRight[pieces[i].depth] = pieces[i].topLeftCorner.X;
                    }
                }
            }
        }

        private void calculate()
        {
            maxDepth = 0;
            now = 0;
            isHidding = false;
            mostRight.Clear();
            stack.Clear();
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].status == true)
                {
                    stack.Push(i);
                    if ( stack.Count > maxDepth)
                    {
                        if (!isHidding)
                        {
                            maxDepth = stack.Count;
                        }
                            mostRight.Add(0.0);
              
                    }
                    pieces[i].depth = stack.Count - 1;
                    pieces[i].sonNum = 0;
                    pieces[i].sumPoint.X = 0;
                    pieces[i].topLeftCorner.X = 0;
                    pieces[i].topLeftCorner.Y = 0;
                    if (!isHidding && (pieces[i].isChildTreeHidden == true || pieces[i].isHidden == true) )
                    {//开始进入隐藏显示
                        isHidding = true;
                        root = i;
                    }
                }
                else
                {
                    now = stack.Pop();
                    if (isHidding && now != root)
                    {
                        continue;
                    }
                    else if (isHidding && now == root)
                    {
                        isHidding = false;
                        if (pieces[now].isHidden == true) continue;
                    }
                    if (pieces[now].sonNum == 0 )//叶节点
                    {
                            pieces[now].topLeftCorner.X = MaxBound(stack.Count, true) + Constant.hDelta;
                            pieces[now].topLeftCorner.Y = stack.Count * Constant.vDelta;
                            mostRight[stack.Count] = pieces[now].topLeftCorner.X;
                        
                    }
                    else
                    {
                        pieces[now].topLeftCorner.X = pieces[now].sumPoint.X / pieces[now].sonNum;
                        pieces[now].topLeftCorner.Y = stack.Count * Constant.vDelta;
                        if (MaxBound(stack.Count, false) + Constant.hDelta < pieces[now].topLeftCorner.X)//该层最右处可以放置
                            {
                                mostRight[stack.Count] = pieces[now].topLeftCorner.X;
                            }
                            else//平移
                            {
                                shiftChildTree(now, i, MaxBound(stack.Count, false) + Constant.hDelta - pieces[now].topLeftCorner.X);
                                pieces[now].topLeftCorner.X = MaxBound(stack.Count, false) + Constant.hDelta;
                                mostRight[stack.Count] = pieces[now].topLeftCorner.X;
                            }
                    }

                    if (stack.Count != 0)
                    {
                        pieces[stack.Peek()].sumPoint.X += pieces[now].topLeftCorner.X;
                        pieces[stack.Peek()].sonNum++;
                    }
                }
            }//for
            while (stack.Count != 0)
            {
                now = stack.Pop();
                    if (isHidding && now != root)
                    {
                        continue;
                    }
                    else if (isHidding && now == root)
                    {
                        isHidding = false;
                        if (pieces[now].isHidden == true) continue;
                    }
                    if (pieces[now].sonNum == 0)//叶节点
                    {
                            pieces[now].topLeftCorner.X = MaxBound(stack.Count, true) + Constant.hDelta;
                            pieces[now].topLeftCorner.Y = stack.Count * Constant.vDelta;
                            mostRight[stack.Count] = pieces[now].topLeftCorner.X;
                        
                    }
                    else
                    {
                        pieces[now].topLeftCorner.X = pieces[now].sumPoint.X / pieces[now].sonNum;
                        pieces[now].topLeftCorner.Y = stack.Count * Constant.vDelta;
                        if (MaxBound(stack.Count, false) + Constant.hDelta < pieces[now].topLeftCorner.X)//该层最右处可以放置
                            {
                                mostRight[stack.Count] = pieces[now].topLeftCorner.X;
                            }
                            else//平移
                            {
                                shiftChildTree(now, pieces.Count, MaxBound(stack.Count, false) + Constant.hDelta - pieces[now].topLeftCorner.X);
                                pieces[now].topLeftCorner.X = MaxBound(stack.Count, false) + Constant.hDelta;
                                mostRight[stack.Count] = pieces[now].topLeftCorner.X;
                            }
                    }

                    if (stack.Count != 0)
                    {
                        pieces[stack.Peek()].sumPoint.X += pieces[now].topLeftCorner.X;
                        pieces[stack.Peek()].sonNum++;
                    }
            }
            double maxMostRight = 0;
            for (int i = 0; i < mostRight.Count; i++)
            {
                if (maxMostRight < mostRight[i])
                    maxMostRight = mostRight[i];
            }
           if(drawingCanvas.Width < maxMostRight + Constant.hDelta)
                drawingCanvas.Width = maxMostRight + Constant.hDelta;
            if(drawingCanvas.Height < (maxDepth) * Constant.vDelta)
                drawingCanvas.Height = (maxDepth) * Constant.vDelta;
               
            
        }//void calulate

        private void drawTreeGraph()
        {
            now = 0;
            stack.Clear();
            isHidding = false;
       

            DrawControl dctrl = new DrawControl(drawingCanvas);
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].status == true)
                {
                    stack.Push(i);
                    if (!isHidding && (pieces[i].isChildTreeHidden == true || pieces[i].isHidden ==true) )
                    {//开始进入隐藏显示
                        isHidding = true;
                        root = i;
                    }
                }
                else
                {
                    now = stack.Pop();
                    if (isHidding && now != root)
                    {
                        continue;
                    }
                    
                    if (stack.Count != 0 && pieces[now].isHidden==false)
                    {
                        Point sonPoint = dctrl.calculateBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName);
                        Point fatherPoint = dctrl.calculateBlock(pieces[stack.Peek()].topLeftCorner, pieces[stack.Peek()].className, pieces[stack.Peek()].functionName);
                        dctrl.addCenterLine(sonPoint, fatherPoint);
                    }
                    if (isHidding && now == root)
                    {
                        isHidding = false;
                        if (pieces[now].isHidden == true) continue;
                        visualDict.Add(dctrl.addContainBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName), now);
                    }
                    else if (pieces[now].isHighlight == true)
                    {
                        visualDict.Add(dctrl.addHighlightBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName), now);
                    }
                    else
                    {
                        visualDict.Add( dctrl.addBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName), now);
                    }
                }
            }//for
            while (stack.Count != 0)
            {
                now = stack.Pop();
                if (isHidding && now != root)
                {
                    continue;
                }

                if (stack.Count != 0 && pieces[now].isHidden == false)
                {
                    Point sonPoint = dctrl.calculateBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName);
                    Point fatherPoint = dctrl.calculateBlock(pieces[stack.Peek()].topLeftCorner, pieces[stack.Peek()].className, pieces[stack.Peek()].functionName);
                    dctrl.addCenterLine(sonPoint, fatherPoint);
                }
                if (isHidding && now == root)
                {
                    isHidding = false;
                    if (pieces[now].isHidden == true) continue;
                    visualDict.Add(dctrl.addContainBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName), now);
                }
                else
                {
                    visualDict.Add(dctrl.addBlock(pieces[now].topLeftCorner, pieces[now].className, pieces[now].functionName), now);
                }
            }
        }//void drawTree
    }

    public class Constant
    {
        public const double vDelta = 80;//垂直间距
        public const double hDelta = 160;//水平间距
    }

}

