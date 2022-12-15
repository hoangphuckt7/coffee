// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';
import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/item/item_model.dart';
import 'package:orderr_app/models/order/detail_dct_model.dart';
import 'package:orderr_app/models/order/order_model.dart';
import 'package:orderr_app/models/table/change_orders_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/repositories/floor_repo.dart';
import 'package:orderr_app/repositories/item_repo.dart';
import 'package:orderr_app/repositories/order_repo.dart';
import 'package:orderr_app/repositories/table_repo.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/local_storage.dart';

part 'change_table_event.dart';
part 'change_table_state.dart';

class ChangeTableBloc extends Bloc<ChangeTableEvent, ChangeTableState> {
  final _floorRepo = FloorRepo();
  final _tableRepo = TableRepo();
  final _orderRepo = OrderRepo();
  final _itemRepo = ItemRepo();
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
    on<CTUpdateSelectedOrdersEvent>(_onUpdateSelectedOrders);
    on<CTUpdateCbxAllEvent>(_onUpdateCbxAll);
    on<CTShowPopupSelectTableNewEvent>(_onChangeVisibleSelectTablweNewPopup);
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
      List<OrderModel> lstOrder = <OrderModel>[];
      if (lstTableOld.isNotEmpty && selectedFloorOld != null) {
        lstTableOld = lstTableOld
            .where((x) => x.floor!.id == selectedFloorOld!.id)
            .toList();
        if (lstTableOld.isNotEmpty) {
          selectedTableOld = lstTableOld[0];
          lstOrder = await _orderRepo.getNewOrdersByTable(selectedTableOld.id!);
          if (lstOrder.isNotEmpty) {
            lstOrder = await _convertLstOrder(lstOrder);
          }
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
        lstOrder,
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
        const <OrderModel>[],
      ));
    }
  }

  void _onChangeVisibleConfirmPopup(
      CTShowPopupConfirmChangeEvent event, Emitter<ChangeTableState> emit) {
    emit(CTShowPopupConfirmChangeState(event.isVisible));
  }

  void _conChangeFloorOld(
      CTChangeFloorOldEvent event, Emitter<ChangeTableState> emit) async {
    emit(CTUpdatedLoadingState(true, 'Đang tải Order...'));
    BaseModel floor = event.floor;
    List<TableModel> listTable = await _tableRepo.fetchListTable();
    listTable = listTable.where((x) => x.floor?.id == floor.id).toList();
    List<OrderModel> lstOrder = <OrderModel>[];

    TableModel? selectedTable;
    if (listTable.isNotEmpty) {
      selectedTable = listTable[0];
      lstOrder = await _orderRepo.getNewOrdersByTable(selectedTable.id!);
      if (lstOrder.isNotEmpty) {
        lstOrder = await _convertLstOrder(lstOrder);
      }
    }
    emit(CTChangedFloorOldState(floor, listTable, selectedTable, lstOrder));
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
      CTChangeTableOldEvent event, Emitter<ChangeTableState> emit) async {
    emit(CTUpdatedLoadingState(true, 'Đang tải Order...'));
    TableModel table = event.table;
    try {
      List<OrderModel> listOrder =
          await _orderRepo.getNewOrdersByTable(table.id!);
      listOrder = await _convertLstOrder(listOrder);
      emit(CTChangedTableOldState(table, listOrder));
    } catch (e) {
      emit(CTErrorState(
          "Lỗi! không thể tải order của bàn ${table.description}"));
    }
  }

  void _onChangeTableNew(
      CTChangeTableNewEvent event, Emitter<ChangeTableState> emit) {
    emit(CTChangedTableNewState(event.table));
  }

  void _onConfirmChange(
      CTConfirmChangeEvent event, Emitter<ChangeTableState> emit) async {
    try {
      var resp = await _tableRepo.changeTableOrders(ChangeOrdersModel(
        event.lstSelectedOrder,
        event.tableIdNew,
      ));
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
      log('ChangeTableBloc - _onConfirmChange - ${e.toString()}');
      emit(CTErrorState(e.toString()));
    }
  }

  void _onUpdateSelectedOrders(
      CTUpdateSelectedOrdersEvent event, Emitter<ChangeTableState> emit) {
    String? orderId = event.orderId;
    List<String?> lstSelectedOrder = event.listSelectedOrder;
    if (lstSelectedOrder.isEmpty) {
      lstSelectedOrder = <String?>[];
    }
    try {
      if (event.listSelectedOrder.contains(orderId)) {
        event.listSelectedOrder.remove(orderId);
      } else {
        lstSelectedOrder.add(orderId);
      }
      emit(CTUpdateSelectedOrdersState(lstSelectedOrder));
    } catch (e) {
      log('ChangeTableBloc - _onUpdateSelectedOrders - ${e.toString()}');
      emit(CTErrorState(e.toString()));
    }
  }

  void _onUpdateCbxAll(
      CTUpdateCbxAllEvent event, Emitter<ChangeTableState> emit) async {
    List<OrderModel> lstOrder = event.lstOrder;
    int selLen = event.selLen;
    try {
      if (selLen == 0) {
        emit(CTUpdateCbxAllState(lstOrder.map((e) => e.id).toList()));
      } else {
        emit(CTUpdateCbxAllState(const <String?>[]));
      }
    } catch (e) {
      log('ChangeTableBloc - _onUpdateCbxAll - ${e.toString()}');
      emit(CTErrorState(e.toString()));
    }
  }

  void _onChangeVisibleSelectTablweNewPopup(
      CTShowPopupSelectTableNewEvent event, Emitter<ChangeTableState> emit) {
    emit(CTShowPopupSelectTableNewState(event.isVisible));
  }

  _convertLstOrder(List<OrderModel> lstOrder) async {
    List<ItemModel> lstItem = <ItemModel>[];
    String? itemJson = await LocalStorage.getItem(KeyLS.items);
    if (itemJson != null && itemJson.isNotEmpty) {
      lstItem = List<ItemModel>.from(
        jsonDecode(itemJson).map((model) => ItemModel.fromJson(model)),
      );
    }
    if (lstItem.isEmpty) {
      lstItem = await _itemRepo.getAll();
    }
    if (lstItem.isNotEmpty) {
      for (var order in lstOrder) {
        if (order.orderDetails != null && order.orderDetails!.isNotEmpty) {
          for (var detail in order.orderDetails!) {
            ItemModel item = lstItem.firstWhere((x) => x.id == detail.itemId);
            detail.item = item;
            if (detail.description != null && detail.description!.isNotEmpty) {
              detail.listDescription = List<DetailDctModel>.from(
                jsonDecode(detail.description!)
                    .map((model) => DetailDctModel.fromJson(model)),
              );
            }
          }
        }
      }
    }
    return lstOrder;
  }
}
