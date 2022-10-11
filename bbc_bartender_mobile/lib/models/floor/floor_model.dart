import 'package:json_annotation/json_annotation.dart';

part 'floor_model.g.dart';

@JsonSerializable()
class FloorModel {
  final String? id;
  final String? description;

  FloorModel(this.id, this.description);

  factory FloorModel.fromJson(Map<String, dynamic> json) =>
      _$FloorModelFromJson(json);

  Map<String, dynamic> toJson() => _$FloorModelToJson(this);
}
