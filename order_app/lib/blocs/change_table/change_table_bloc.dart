// ignore_for_file: depend_on_referenced_packages

import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'change_table_event.dart';
part 'change_table_state.dart';

class ChangeTableBloc extends Bloc<ChangeTableEvent, ChangeTableState> {
  ChangeTableBloc() : super(CTInitialState()) {
    on<CTLoadFloorTableEvent>(_onLoadFloorTable);
  }

  void _onLoadFloorTable(
      CTLoadFloorTableEvent event, Emitter<ChangeTableState> emit) {}
}
