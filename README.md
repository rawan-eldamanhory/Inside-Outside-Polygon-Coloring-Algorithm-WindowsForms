# Inside-Outside Polygon Coloring Algorithm

This project demonstrates the **inside-outside polygon test algorithm** using **C# and Windows Forms**.

The application draws a polygon and colors the pixels inside it with one color and outside with another.

## 📌 Features
- Visualizes inside and outside regions of a polygon
- Uses ray-casting algorithm to detect if a point is inside the polygon
- Works with complex polygon shapes

## 🎨 Visualization
- DarkGray outline: polygon edges
- Black fill: inside polygon
- LightGray fill: outside polygon

## 🧠 Algorithm Overview
The ray-casting algorithm works by:
1. Drawing a horizontal ray from the test point
2. Counting intersections with polygon edges
3. If the number of intersections is odd, the point is inside; otherwise, outside

## 🛠️ Technologies Used
- C#
- .NET
- Windows Forms
- Graphics (GDI+)

## ▶️ How to Run
1. Open `WindowsFormsApp1.sln` in Visual Studio
2. Build and run the project
3. The polygon will be automatically colored when the form is rendered

## 📄 License
Educational use only.
