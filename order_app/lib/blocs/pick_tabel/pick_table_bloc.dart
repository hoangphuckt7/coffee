// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';
import 'dart:developer';

import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/repositories/floor_repo.dart';
import 'package:orderr_app/repositories/table_repo.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/local_storage.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'pick_table_event.dart';
part 'pick_table_state.dart';

class PickTableBloc extends Bloc<PickTableEvent, PickTableState> {
  final FloorRepo _floorRepo = FloorRepo();
  final TableRepo _tableRepo = TableRepo();

  PickTableBloc() : super(PTInitialState()) {
    on<PTLoadFloorTableEvent>(_onLoadData);
    on<PTChangeFloorEvent>(_onChangeFloor);
    on<PTChangeTableEvent>(_onChangeTable);
    on<PTShowPopupConfirmExitEvent>(_onShowPopupConfirmExit);
  }

  void _onLoadData(
      PTLoadFloorTableEvent event, Emitter<PickTableState> emit) async {
    emit(PTUpdatedLoadingState(true, 'Đang tải dữ liệu...'));
    try {
      var lstFloor = await _floorRepo.getAll();
      await LocalStorage.setItem(KeyLS.floors, jsonEncode(lstFloor));
      BaseModel? selectedFloor = event.floor;
      if (lstFloor.isNotEmpty) {
        selectedFloor ??= lstFloor[0];
      }

      var lstTable = await _tableRepo.getAll();
      await LocalStorage.setItem(KeyLS.tables, jsonEncode(lstTable));
      TableModel? selectedTable = event.table;
      if (selectedFloor != null) {
        lstTable =
            lstTable.where((x) => x.floor!.id == selectedFloor!.id).toList();
        if (lstTable.isNotEmpty) {
          selectedTable ??= lstTable[0];
        }
      }
      emit(PTLoadedFloorTableState(
        selectedFloor,
        lstFloor,
        selectedTable,
        lstTable,
      ));
    } catch (e) {
      emit(PTLoadedFloorTableState(
        null,
        const <BaseModel>[],
        null,
        const <TableModel>[],
      ));
    }
  }

  void _onChangeFloor(
      PTChangeFloorEvent event, Emitter<PickTableState> emit) async {
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
    emit(PTChangedFloorState(floor, listTable, selectedTable));
  }

  void _onChangeTable(PTChangeTableEvent event, Emitter<PickTableState> emit) {
    emit(PTChangedTableState(event.table));
  }

  void _onShowPopupConfirmExit(
      PTShowPopupConfirmExitEvent event, Emitter<PickTableState> emit) {
    emit(PTShowPopupConfirmExitState(event.isVisible));
  }
}
