// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';

import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/repositories/floor_repo.dart';
import 'package:orderr_app/repositories/table_repo.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/local_storage.dart';

part 'change_table_event.dart';
part 'change_table_state.dart';

class ChangeTableBloc extends Bloc<ChangeTableEvent, ChangeTableState> {
  final _floorRepo = FloorRepo();
  final _tableRepo = TableRepo();
  ChangeTableBloc() : super(CTInitialState()) {
    on<CTLoadFloorTableEvent>(_onLoadFloorTable);
    on<CTChangeVisibleConfirmPopupEvent>(_onChangeVisibleConfirmPopup);
  }

  void _onLoadFloorTable(
      CTLoadFloorTableEvent event, Emitter<ChangeTableState> emit) async {
    emit(CTUpdatedLoadingState(true, 'Đang tải dữ liệu...'));
    try {
      // Lấy thông tin khu vực
      BaseModel? selectedFloorOld;
      BaseModel? selectedFloorNew;
      List<BaseModel> lstFloor = <BaseModel>[];
      String? floorJson = await LocalStorage.getItem(KeyLS.floors);
      if (floorJson != null && floorJson.isNotEmpty) {
        lstFloor = List<BaseModel>.from(
          jsonDecode(floorJson).map((model) => BaseModel.fromJson(model)),
        );

        if (lstFloor.isEmpty) {
          lstFloor = await _floorRepo.getAll();
          await LocalStorage.setItem(KeyLS.floors, jsonEncode(lstFloor));
        }

        if (lstFloor.isNotEmpty) {
          selectedFloorOld = lstFloor[0];
          selectedFloorNew = lstFloor[0];
        }
      }

      // Lấy thông tin bàn
      TableModel? selectedTableOld;
      TableModel? selectedTableNew;
      List<TableModel> lstTableOld = <TableModel>[];
      List<TableModel> lstTableNew = <TableModel>[];
      String? tableJson = await LocalStorage.getItem(KeyLS.tables);
      if (tableJson != null && tableJson.isNotEmpty) {
        lstTableOld = List<TableModel>.from(
          jsonDecode(tableJson).map((model) => TableModel.fromJson(model)),
        );

        if (lstTableOld.isEmpty) {
          lstTableOld = await _tableRepo.getAll();
          await LocalStorage.setItem(KeyLS.tables, jsonEncode(lstTableOld));
        }

        lstTableNew = lstTableOld;

        if (selectedFloorOld != null) {
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
      CTChangeVisibleConfirmPopupEvent event, Emitter<ChangeTableState> emit) {
    emit(CTChangedVisibleConfirmPopupState(event.isVisible));
  }
}
