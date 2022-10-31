import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/repositories/category_repo.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bbc_order_mobile/utils/local_storage.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'order_event.dart';
part 'order_state.dart';

class OrderBloc extends Bloc<OrderEvent, OrderState> {
  final CategoryRepo _cateRepo = CategoryRepo();
  final ItemRepo _itemRepo = ItemRepo();
  OrderBloc() : super(InitialState()) {
    on<LoadCateItemEvent>(_onLoadCateItem);
    on<FilterEvent>(_onFilter);
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
        lstItem = lstItem
            .where((x) =>
                x.categoryId == 'ALL' ||
                x.categoryId == null ||
                x.categoryId == cate.id)
            .toList();
      }
      emit(FilteredState(cate, searchVal, lstItem));
    } catch (e) {
      log('OrderBloc - _onFilter - ${e.toString()}');
      emit(ErrorState('Lỗi!'));
    }
  }
}
