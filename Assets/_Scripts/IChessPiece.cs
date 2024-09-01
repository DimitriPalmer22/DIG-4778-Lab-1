using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChessPiece
{
  void OnDrawGizmosSelected();
  void CheckTag();
}
