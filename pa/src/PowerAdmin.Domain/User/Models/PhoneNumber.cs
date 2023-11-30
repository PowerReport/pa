namespace PowerAdmin.Domain.User.Models;

using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 手机号码模型
/// </summary>
public class PhoneNumber {
  private string phoneNumber = default!;

  /// <summary>
  /// 将 <see cref="string"/> 隐式转换为 <see cref="PhoneNumber"/>
  /// 并且校验手机号码格式是否合法
  /// </summary>
  /// <param name="str"></param>
  public static implicit operator PhoneNumber(string str) {
    // 校验输入的字符串是否合法
    ValidatePhoneNumber(str);

    return new PhoneNumber { phoneNumber = str };
  }

  /// <summary>
  /// 将 <see cref="PhoneNumber"/> 隐式转换为 <see cref="string"/>
  /// </summary>
  /// <param name="phoneNumber"><see cref="PhoneNumber"/>
  /// 的字符串表现形式</param>
  public static implicit
  operator string(PhoneNumber phoneNumber) => phoneNumber.ToString();

  /// <summary>
  /// 将 <see cref="PhoneNumber"/> 转换为字符串表现形式
  /// </summary>
  /// <returns><see cref="PhoneNumber"/> 的字符串表现形式</returns>
  public override string ToString() => phoneNumber;

  public override int GetHashCode() => phoneNumber.GetHashCode();

  /// <summary>
  /// 校验手机号码格式是否合法
  /// </summary>
  /// <param name="str"></param>
  private static void ValidatePhoneNumber(string str) {
    if (string.IsNullOrWhiteSpace(str) || !IsPhoneNumber(str)) {
      throw Oops.Bah("不正确的手机号码格式: {0}!", str);
    }
  }

  /// <summary>
  /// 判断 <see cref="string"/> 是否手机号码
  /// </summary>
  /// <param name="str"></param>
  /// <returns></returns>
  private static bool IsPhoneNumber(string str) {
    // TODO: 实现手机号码的验证规则
    return true;
  }
}
