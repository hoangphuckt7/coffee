import 'package:json_annotation/json_annotation.dart';

part 'base_model.g.dart';

@JsonSerializable()
class BaseModel {
  final String? id;
  final String? description;
  final DateTime? dateCreated;
  final DateTime? dateUpdated;
  final bool? isDeleted;

  BaseModel(
    this.id,
    this.description,
    this.dateCreated,
    this.dateUpdated,
    this.isDeleted,
  );

  factory BaseModel.fromJson(Map<String, dynamic> json) =>
      _$BaseModelFromJson(json);

  Map<String, dynamic> toJson() => _$BaseModelToJson(this);
}
