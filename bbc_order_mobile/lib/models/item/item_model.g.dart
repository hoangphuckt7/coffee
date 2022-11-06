// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'item_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ItemModel _$ItemModelFromJson(Map<String, dynamic> json) => ItemModel(
      json['id'] as String?,
      json['description'] as String?,
      json['dateCreated'] == null
          ? null
          : DateTime.parse(json['dateCreated'] as String),
      json['dateUpdated'] == null
          ? null
          : DateTime.parse(json['dateUpdated'] as String),
      json['isDeleted'] as bool?,
      json['name'] as String?,
      (json['price'] as num?)?.toDouble(),
      json['available'] as bool?,
      json['categoryId'] as String?,
      json['category'] == null
          ? null
          : BaseModel.fromJson(json['category'] as Map<String, dynamic>),
      (json['images'] as List<dynamic>?)?.map((e) => e as String).toList(),
      json['sugar'] == null ? 100 : json['sugar'] as int?,
      json['ice'] == null ? 100 : json['ice'] as int?,
    );

Map<String, dynamic> _$ItemModelToJson(ItemModel instance) => <String, dynamic>{
      'id': instance.id,
      'description': instance.description,
      'dateCreated': instance.dateCreated?.toIso8601String(),
      'dateUpdated': instance.dateUpdated?.toIso8601String(),
      'isDeleted': instance.isDeleted,
      'name': instance.name,
      'price': instance.price,
      'available': instance.available,
      'categoryId': instance.categoryId,
      'category': instance.category,
      'images': instance.images,
      'sugar': instance.sugar,
      'ice': instance.ice,
    };
