import 'package:json_annotation/json_annotation.dart';

part 'pass_change_model.g.dart';

@JsonSerializable()
class PassChangeModel {
  final String? oldPassword;
  final String? newPassword;
  final String? newPasswordConfirm;

  PassChangeModel(this.oldPassword, this.newPassword, this.newPasswordConfirm);

  factory PassChangeModel.fromJson(Map<String, dynamic> json) =>
      _$PassChangeModelFromJson(json);

  Map<String, dynamic> toJson() => _$PassChangeModelToJson(this);
}
