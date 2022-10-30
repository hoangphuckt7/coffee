import 'package:bbc_order_mobile/repositories/category_repo.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'order_event.dart';
part 'order_state.dart';

class OrderBloc extends Bloc<OrderEvent, OrderState> {
  final CategoryRepo _cateRepo = CategoryRepo();
  final ItemRepo _itemRepo = ItemRepo();
  OrderBloc() : super(InitialState()) {
    on<LoadCateItemEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
