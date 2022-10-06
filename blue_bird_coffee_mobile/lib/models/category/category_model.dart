import 'package:json_annotation/json_annotation.dart';

part 'category_model.g.dart';

@JsonSerializable()
class CategoryModel {
  final String id;
  final String description;
  final bool isDeleted;
  final DateTime dateCreated;
  final DateTime dateUpdated;

  CategoryModel(
    this.id,
    this.description,
    this.isDeleted,
    this.dateCreated,
    this.dateUpdated,
  );

  factory CategoryModel.fromJson(Map<String, dynamic> json) =>
      _$CategoryModelFromJson(json);

  Map<String, dynamic> toJson() => _$CategoryModelToJson(this);
}
