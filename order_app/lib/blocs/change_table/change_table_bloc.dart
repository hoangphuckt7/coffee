// ignore_for_file: depend_on_referenced_packages

import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/repositories/floor_repo.dart';
import 'package:orderr_app/repositories/table_repo.dart';

part 'change_table_event.dart';
part 'change_table_state.dart';

class ChangeTableBloc extends Bloc<ChangeTableEvent, ChangeTableState> {
  final _floorRepo = FloorRepo();
  final _tableRepo = TableRepo();
  ChangeTableBloc() : super(CTInitialState()) {
    on<CTLoadFloorTableEvent>(_onLoadFloorTable);
    on<CTShowPopupConfirmChangeEvent>(_onChangeVisibleConfirmPopup);
    // Change floor and table old
    on<CTChangeFloorOldEvent>(_conChangeFloorOld);
    on<CTChangeTableOldEvent>(_onChangeTableOld);
    // Change floor and table old
    on<CTChangeFloorNewEvent>(_onChangeFloorNew);
    on<CTChangeTableNewEvent>(_onChangeTableNew);
    // confirm
    on<CTConfirmChangeEvent>(_onConfirmChange);
  }

  void _onLoadFloorTable(
      CTLoadFloorTableEvent event, Emitter<ChangeTableState> emit) async {
    emit(CTUpdatedLoadingState(true, 'Đang tải dữ liệu...'));
    try {
      // Lấy thông tin khu vực
      BaseModel? selectedFloorOld;
      BaseModel? selectedFloorNew;
      List<BaseModel> lstFloor = await _floorRepo.fetchListFloor();
      if (lstFloor.isNotEmpty) {
        selectedFloorOld = lstFloor[0];
        selectedFloorNew = lstFloor[0];
      }

      // Lấy thông tin bàn
      TableModel? selectedTableOld;
      TableModel? selectedTableNew;
      List<TableModel> lstTableOld = await _tableRepo.fetchListTable();
      List<TableModel> lstTableNew = lstTableOld;

      if (lstTableOld.isNotEmpty && selectedFloorOld != null) {
        lstTableOld = lstTableOld
            .where((x) => x.floor!.id == selectedFloorOld!.id)
            .toList();
        if (lstTableOld.isNotEmpty) {
          selectedTableOld = lstTableOld[0];
        }
      }

      if (selectedFloorNew != null) {
        lstTableNew = lstTableNew
            .where((x) => x.floor!.id == selectedFloorNew!.id)
            .toList();
        if (lstTableNew.isNotEmpty) {
          selectedTableNew = lstTableNew[0];
        }
      }

      emit(CTLoadedFloorTableState(
        selectedFloorOld,
        selectedTableOld,
        selectedFloorNew,
        selectedTableNew,
        lstFloor,
        lstTableOld,
        lstTableNew,
      ));
    } catch (e) {
      log('ChangeTableBloc - _onLoadFloorTable - ${e.toString()}');
      emit(CTLoadedFloorTableState(
        null,
        null,
        null,
        null,
        const <BaseModel>[],
        const <TableModel>[],
        const <TableModel>[],
      ));
    }
  }

  void _onChangeVisibleConfirmPopup(
      CTShowPopupConfirmChangeEvent event, Emitter<ChangeTableState> emit) {
    emit(CTShowPopupConfirmChangeState(event.isVisible));
  }

  void _conChangeFloorOld(
      CTChangeFloorOldEvent event, Emitter<ChangeTableState> emit) async {
    BaseModel floor = event.floor;
    List<TableModel> listTable = await _tableRepo.fetchListTable();
    listTable = listTable.where((x) => x.floor?.id == floor.id).toList();

    TableModel? selectedTable;
    if (listTable.isNotEmpty) {
      selectedTable = listTable[0];
    }
    emit(CTChangedFloorOldState(floor, listTable, selectedTable));
  }

  void _onChangeFloorNew(
      CTChangeFloorNewEvent event, Emitter<ChangeTableState> emit) async {
    BaseModel floor = event.floor;
    List<TableModel> listTable = await _tableRepo.fetchListTable();
    listTable = listTable.where((x) => x.floor?.id == floor.id).toList();

    TableModel? selectedTable;
    if (listTable.isNotEmpty) {
      selectedTable = listTable[0];
    }
    emit(CTChangedFloorNewState(floor, listTable, selectedTable));
  }

  void _onChangeTableOld(
      CTChangeTableOldEvent event, Emitter<ChangeTableState> emit) {
    emit(CTChangedTableOldState(event.table));
  }

  void _onChangeTableNew(
      CTChangeTableNewEvent event, Emitter<ChangeTableState> emit) {
    emit(CTChangedTableNewState(event.table));
  }

  void _onConfirmChange(
      CTConfirmChangeEvent event, Emitter<ChangeTableState> emit) async {
    try {
      var resp =
          await _tableRepo.changeTable(event.tableIdOld, event.tableIdNew);
      if (resp is bool && resp) {
        emit(CTGoToPickTableState());
        return;
      }
      if (resp is String && resp.isNotEmpty) {
        throw resp;
      } else {
        emit(CTErrorState('Chuyển / Gộp bàn thất bại'));
      }
    } catch (e) {
      log('ChangeTableBloc - _onLoadFloorTable - ${e.toString()}');
      emit(CTErrorState(e.toString()));
    }
  }
}
