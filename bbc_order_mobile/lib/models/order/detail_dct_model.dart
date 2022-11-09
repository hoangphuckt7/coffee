// ignore_for_file: non_constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

part 'detail_dct_model.g.dart';

@JsonSerializable()
class DetailDctModel {
  int? Sugar;
  int? Ice;
  String? Note;

  DetailDctModel(this.Sugar, this.Ice, this.Note);

  factory DetailDctModel.fromJson(Map<String, dynamic> json) =>
      _$DetailDctModelFromJson(json);

  Map<String, dynamic> toJson() => _$DetailDctModelToJson(this);
}
