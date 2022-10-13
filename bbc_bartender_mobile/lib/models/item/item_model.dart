import 'package:bbc_bartender_mobile/models/common/base_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'item_model.g.dart';

@JsonSerializable()
class ItemModel {
  final String? id;
  final String? description;
  final DateTime? dateCreated;
  final DateTime? dateUpdated;
  final bool? isDeleted;
  final String? name;
  final double? price;
  final bool? available;
  final String? categoryId;
  final BaseModel? category;

  ItemModel(
    this.id,
    this.description,
    this.dateCreated,
    this.dateUpdated,
    this.isDeleted,
    this.name,
    this.price,
    this.available,
    this.categoryId,
    this.category,
  );

  factory ItemModel.fromJson(Map<String, dynamic> json) =>
      _$ItemModelFromJson(json);

  Map<String, dynamic> toJson() => _$ItemModelToJson(this);
}
