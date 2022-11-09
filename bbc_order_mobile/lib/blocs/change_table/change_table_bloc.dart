import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'change_table_event.dart';
part 'change_table_state.dart';

class ChangeTableBloc extends Bloc<ChangeTableEvent, ChangeTableState> {
  ChangeTableBloc() : super(ChangeTableInitial()) {
    on<ChangeTableEvent>((event, emit) {
      // TODO: implement event handler
    });
  }
}
