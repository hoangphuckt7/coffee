// import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'login_res_model.g.dart';

@JsonSerializable()
class LoginResModel {
  String? fullname;
  final String? token;
  final String? role;

  LoginResModel(
    this.fullname,
    this.token,
    this.role,
  );

  factory LoginResModel.fromJson(Map<String, dynamic> json) =>
      _$LoginResModelFromJson(json);

  Map<String, dynamic> toJson() => _$LoginResModelToJson(this);
}
