import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  XXXEntitySingularXXXServiceProxy,
  XXXEntitySingularXXXDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-XXXEntityLowerSingularXXX-dialog.component.html'
})
export class EditXXXEntitySingularXXXDialogComponent extends AppComponentBase
    implements OnInit {
  saving = false;
  XXXEntityLowerSingularXXX: XXXEntitySingularXXXDto = new XXXEntitySingularXXXDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
      injector: Injector,
      public _XXXEntityLowerSingularXXXService: XXXEntitySingularXXXServiceProxy,
      public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._XXXEntityLowerSingularXXXService.get(this.id).subscribe((result: XXXEntitySingularXXXDto) => {
      this.XXXEntityLowerSingularXXX = result;
    });
  }

  save(): void {
    this.saving = true;

    this._XXXEntityLowerSingularXXXService.update(this.XXXEntityLowerSingularXXX).subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
    );
  }
}
