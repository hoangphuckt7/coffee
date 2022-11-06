// ignore_for_file: depend_on_referenced_packages, unnecessary_null_comparison

import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_order_mobile/models/order/order_create_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_model.dart';
import 'package:bbc_order_mobile/repositories/category_repo.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bbc_order_mobile/utils/local_storage.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:tiengviet/tiengviet.dart';

part 'order_event.dart';
part 'order_state.dart';

class OrderBloc extends Bloc<OrderEvent, OrderState> {
  final CategoryRepo _cateRepo = CategoryRepo();
  final ItemRepo _itemRepo = ItemRepo();
  OrderBloc() : super(InitialState()) {
    on<LoadCateItemEvent>(_onLoadCateItem);
    on<FilterEvent>(_onFilter);
    on<ChangeSugarEvent>(_onChangeSugar);
    on<ChangeIceEvent>(_onChangeIce);
    on<AddToCartEvent>(_onAddingToCart);
  }

  void _onLoadCateItem(
      LoadCateItemEvent event, Emitter<OrderState> emit) async {
    emit(UpdatedLoadingState(true, 'Đang tải dữ liệu...'));
    try {
      var lstItem = await _itemRepo.getAll();
      if (lstItem.isNotEmpty) {
        await LocalStorage.setItem(KeyLS.items, lstItem);
      }

      var lstCateDB = await _cateRepo.getAll();
      var lstCate = <BaseModel>[];
      lstCate.add(
          BaseModel('ALL', 'Tất cả', DateTime.now(), DateTime.now(), false));
      BaseModel selectedCate = lstCate[0];
      if (lstCateDB.isNotEmpty) {
        lstCate.addAll(lstCateDB);
      }
      log('items: ${lstItem.length}');
      emit(LoadedCateItemState(lstCate, selectedCate, lstItem));
    } catch (e) {
      log('OrderBloc - _onLoadCateItem - ${e.toString()}');
      emit(LoadedCateItemState(const <BaseModel>[], null, const <ItemModel>[]));
    }
  }

  void _onFilter(FilterEvent event, Emitter<OrderState> emit) async {
    try {
      BaseModel cate = event.cate;
      String searchVal = event.search;
      var itemJson = await LocalStorage.getItem(KeyLS.items);
      var lstItem = <ItemModel>[];
      if (itemJson != null) {
        lstItem = List<ItemModel>.from(
          jsonDecode(itemJson).map((model) => ItemModel.fromJson(model)),
        );
      }
      if (lstItem.isNotEmpty) {
        lstItem = lstItem.where((x) {
          var checkCate = (cate.id == 'ALL' ||
              x.category?.id == null ||
              x.category?.id == cate.id);
          var searchValConvert = TiengViet.parse(searchVal).toLowerCase();
          var checkSearch = (searchVal.isEmpty ||
              TiengViet.parse(x.name!.toLowerCase())
                  .contains(searchValConvert));
          return checkCate && checkSearch;
        }).toList();
      }

      emit(FilteredState(cate, searchVal, lstItem));
    } catch (e) {
      log('OrderBloc - _onFilter - ${e.toString()}');
      emit(ErrorState('Lỗi!'));
    }
  }

  void _onChangeSugar(ChangeSugarEvent event, Emitter<OrderState> emit) {
    try {
      int step = event.step;
      ItemModel item = event.item;
      if (item.sugar == null) {
        item.sugar = 100 + step;
      } else if (item.sugar! + step >= 0) {
        item.sugar = item.sugar! + step;
      }
      emit(ChangedSugarState(item));
    } catch (e) {
      log('OrderBloc - _onChangeSugar - ${e.toString()}');
    }
  }

  void _onChangeIce(ChangeIceEvent event, Emitter<OrderState> emit) {
    try {
      int step = event.step;
      ItemModel item = event.item;
      if (item.ice == null) {
        item.ice = 100 + step;
      } else if (item.ice! + step >= 0) {
        item.ice = item.ice! + step;
      }
      emit(ChangedIceState(item));
    } catch (e) {
      log('OrderBloc - _onChangeIce - ${e.toString()}');
    }
  }

  void _onAddingToCart(AddToCartEvent event, Emitter<OrderState> emit) {
    try {
      List<OrderDetailCreateModel> lstODetail = event.lstODetail;
      ItemModel item = event.item;
      var dct = DetailDctModel(item.sugar, item.ice, null);
      if (lstODetail.isNotEmpty) {
        var detail = lstODetail.firstWhere((x) => x.itemId == item.id);
        if (detail != null) {
          detail.quantity += 1;
          if (detail.listDct!.isEmpty) {
            detail.listDct = <DetailDctModel>[];
          }
          detail.listDct!.add(dct);
          detail.description = jsonEncode(detail.listDct);
        }
      } else {
        var lstDct = <DetailDctModel>[];
        lstDct.add(dct);
        var detail = OrderDetailCreateModel(
          item.id,
          item,
          1,
          jsonEncode(lstDct),
          lstDct,
        );
        lstODetail.add(detail);
      }
      item.sugar = 100;
      item.ice = 100;
      emit(AddedToCartState(lstODetail, item));
    } catch (e) {
      log('OrderBloc - _onAddingToCart - ${e.toString()}');
    }
  }
}
