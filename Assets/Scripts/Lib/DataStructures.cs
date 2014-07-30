using System;

public struct FixedSize {
  public int width;
  public int height;
}

public struct FixedPosition {
  public int x;
  public int y;

  public FixedPosition(int x, int y) {
    this.x = x;
    this.y = y;
  }

  public double DistanceTo(FixedPosition pos){
    int _x = pos.x - x;
    int _y = pos.y - y;

    return Math.Sqrt(_x * _x + _y * _y);
  }

  public double DistanceTo(int x, int y) {
    int _x = x - this.x;
    int _y = y - this.y;

    return Math.Sqrt(_x * _x + _y * _y);
  }
}