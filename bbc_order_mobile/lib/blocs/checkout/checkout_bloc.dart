import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'checkout_event.dart';
part 'checkout_state.dart';

class CheckoutBloc extends Bloc<CheckoutEvent, CheckoutState> {
  CheckoutBloc() : super(InitialState()) {
    on<CheckoutEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
