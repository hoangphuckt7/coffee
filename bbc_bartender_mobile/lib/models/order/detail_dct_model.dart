import 'package:json_annotation/json_annotation.dart';

part 'detail_dct_model.g.dart';

@JsonSerializable()
class DetailDctModel {
  final int? sugar;
  final int? ice;
  final String? note;

  DetailDctModel(this.sugar, this.ice, this.note);

  factory DetailDctModel.fromJson(Map<String, dynamic> json) =>
      _$DetailDctModelFromJson(json);

  Map<String, dynamic> toJson() => _$DetailDctModelToJson(this);
}
