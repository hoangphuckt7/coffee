// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';

import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/table/table_model.dart';
import 'package:bbc_order_mobile/repositories/floor_repo.dart';
import 'package:bbc_order_mobile/repositories/table_repo.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bbc_order_mobile/utils/local_storage.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'pick_table_event.dart';
part 'pick_table_state.dart';

class PickTableBloc extends Bloc<PickTableEvent, PickTableState> {
  final FloorRepo _floorRepo = FloorRepo();
  final TableRepo _tableRepo = TableRepo();

  PickTableBloc() : super(InitialState()) {
    on<LoadFloorTableEvent>(_onLoadData);
    on<ChangeFloorEvent>(_onChangeFloor);
    on<ChangeTableEvent>(_onChangeTable);
  }

  void _onLoadData(
      LoadFloorTableEvent event, Emitter<PickTableState> emit) async {
    emit(UpdatedLoadingState(true, 'Đang tải dữ liệu...'));
    try {
      var lstFloor = await _floorRepo.getAll();
      await LocalStorage.setItem(KeyLS.floors, jsonEncode(lstFloor));
      BaseModel? selectedFloor;
      if (lstFloor.isNotEmpty) {
        selectedFloor = lstFloor[0];
      }

      var lstTable = await _tableRepo.getAll();
      await LocalStorage.setItem(KeyLS.tables, jsonEncode(lstTable));
      TableModel? selectedTable;
      if (selectedFloor != null) {
        lstTable =
            lstTable.where((x) => x.floor!.id == selectedFloor!.id).toList();
        if (lstTable.isNotEmpty) {
          selectedTable = lstTable[0];
        }
      }
      emit(LoadedFloorTableState(
          selectedFloor, lstFloor, selectedTable, lstTable));
    } catch (e) {
      emit(LoadedFloorTableState(
        null,
        const <BaseModel>[],
        null,
        const <TableModel>[],
      ));
    }
  }

  void _onChangeFloor(
      ChangeFloorEvent event, Emitter<PickTableState> emit) async {
    BaseModel floor = event.floor;
    var tableJson = await LocalStorage.getItem(KeyLS.tables);
    List<TableModel> listTable = List<TableModel>.from(
      jsonDecode(tableJson).map((model) => TableModel.fromJson(model)),
    );

    listTable = listTable.where((x) => x.floor!.id == floor.id).toList();
    TableModel? selectedTable;
    if (listTable.isNotEmpty) {
      selectedTable = listTable[0];
    }
    emit(ChangedFloorState(floor, listTable, selectedTable));
  }

  void _onChangeTable(ChangeTableEvent event, Emitter<PickTableState> emit) {
    emit(ChangedTableState(event.table));
  }
}
