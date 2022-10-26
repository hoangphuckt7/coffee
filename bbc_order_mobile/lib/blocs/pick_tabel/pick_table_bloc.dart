import 'package:bbc_order_mobile/repositories/category_repo.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bbc_order_mobile/repositories/order_repo.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'pick_table_event.dart';
part 'pick_table_state.dart';

class PickTableBloc extends Bloc<PickTableEvent, PickTableState> {
  final CategoryRepo _cateRepo = CategoryRepo();
  final ItemRepo _itemRepo = ItemRepo();
  final OrderRepo _orderRepo = OrderRepo();

  PickTableBloc(
  ) : super(PickTableInitial()) {
    on<LoadDataEvent>(_onLoadData);
  }

  void _onLoadData(LoadDataEvent event, Emitter<PickTableState> emit) {}
}
