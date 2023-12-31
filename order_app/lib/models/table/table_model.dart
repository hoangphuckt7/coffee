import 'package:orderr_app/models/common/base_model.dart';
import 'package:json_annotation/json_annotation.dart';

part 'table_model.g.dart';

@JsonSerializable()
class TableModel {
  final String? id;
  final String? description;
  final int? currentOrder;
  final String? position;
  final String? size;
  final String? shape;
  final int? rotation;
  final BaseModel? floor;

  TableModel(this.id, this.description, this.currentOrder, this.position,
      this.size, this.shape, this.rotation, this.floor);

  factory TableModel.fromJson(Map<String, dynamic> json) =>
      _$TableModelFromJson(json);

  Map<String, dynamic> toJson() => _$TableModelToJson(this);
}
